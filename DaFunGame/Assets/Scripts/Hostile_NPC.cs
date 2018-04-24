using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_NPC : MonoBehaviour 
{
	public float walkSpeed;
	public float spinSpeed;
	public GameObject theBall;


	private Rigidbody2D npcRB;
	private Vector2 walkDir;
	private Vector2 currentSpeed;
	private Vector2 newPosVector;
	private Vector2 rayOffset;
	private float offset = 0.10f;
	private int lastDirChange;
	private int currentDirChange;
	private Vector2 ball;
	private ArrayList path;
	private GameObject pathScout;


	void Start () 
	{
		path = new ArrayList();
		ball = theBall.transform.position;

		npcRB = this.GetComponent<Rigidbody2D>();
		moveUp();
	}
	
	// Update is called once per frame
	void Update () 
	{
		newPosVector = new Vector2(this.transform.position.x + rayOffset.x, this.transform.position.y + rayOffset.y);
		RaycastHit2D npcSight = Physics2D.Raycast(newPosVector, 
		walkDir, 0.01f);

		if(npcSight.collider)
		{
			changeDir();
			Debug.Log("Hit " + npcSight.collider);
		}
		else
		{
			npcRB.AddForce(currentSpeed);
		}

		transform.rotation = Quaternion.Euler(0f, 0f, (Mathf.Rad2Deg * Mathf.Atan2((ball.y - transform.position.y),
		 (ball.x - transform.position.x)) - 90));

		Debug.DrawRay(newPosVector, walkDir * 0.01f);
	}


	private void moveUp()
	{
		currentSpeed = Vector2.up * walkSpeed * Time.deltaTime;
		walkDir = Vector2.up;
		rayOffset = new Vector2 (0f, offset);
		Debug.Log("newPos: " + newPosVector);
	}


	private void moveDown()
	{
		currentSpeed = Vector2.down * walkSpeed * Time.deltaTime;
		walkDir = Vector2.down;
		rayOffset = new Vector2 (0f, -offset);
		Debug.Log("newPos: " + newPosVector);
	}


	private void moveRight()
	{
		currentSpeed = Vector2.right * walkSpeed * Time.deltaTime;
		walkDir = Vector2.right;
		rayOffset = new Vector2 (offset, 0f);
		Debug.Log("newPos: " + newPosVector);
	}


	private void moveLeft()
	{
		currentSpeed = Vector2.left * walkSpeed * Time.deltaTime;
		walkDir = Vector2.left;
		rayOffset = new Vector2 (-offset, 0f);
		Debug.Log("newPos: " + newPosVector);
	}


	private void changeDir()
	{
		Vector2 testingOffset = new Vector2 (0f, 0.20f);
		Vector2 testingDir = Vector2.up;
		float greatestDir = 0;
		int positionOfGreatest = 0;
		float[] distances = new float[4]; 

		for(int i = 0; i < 4; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(this.transform.position.x + testingOffset.x,
			 this.transform.position.y + testingOffset.y), testingDir, Mathf.Infinity);

			if(hit)
			{
				distances[i] = Vector2.Distance(this.transform.position, hit.collider.gameObject.transform.position);
				Debug.Log("Distance of " + i + ": " + distances[i]);

				if(distances[i] > greatestDir && lastDirChange != i)
				{
					greatestDir = distances[i];
					positionOfGreatest = i;
				}
			}

			switch(i)
			{
				case 0: testingOffset = new Vector2 (0f, -offset);
						testingDir = Vector2.down;
				break;
				case 1: testingOffset = new Vector2 (offset, 0f);
						testingDir = Vector2.right;
				break;
				case 2: testingOffset = new Vector2 (-offset, 0f);
						testingDir = Vector2.left;
				break;
			}
		}

		switch(positionOfGreatest)
		{
			case 0: moveUp();
			break;
			case 1: moveDown();
			break;
			case 2: moveRight();
			break;
			case 3: moveLeft();
			break;
		}
		lastDirChange = currentDirChange;
		currentDirChange = positionOfGreatest;
	}


	private void getBall(ArrayList currentList)
	{
		if (ball.Equals(pathScout.transform.position))
		{
			path = currentList;
		}
		else
		{
			currentList.Add(pathScout.transform.position);
			getBall(currentList);
		}
	}
}
