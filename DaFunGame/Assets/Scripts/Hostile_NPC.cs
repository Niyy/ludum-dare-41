using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_NPC : MonoBehaviour 
{
	public float walkSpeed;
	public float spinSpeed;


	private Rigidbody2D npcRB;
	private float runTime;


	void Start () 
	{
		npcRB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	private void moveUp()
	{
		npcRB.AddForce(Vector2.up * walkSpeed);
	}


	private void moveDown()
	{
		npcRB.AddForce(Vector2.down * walkSpeed);
	}


	private void moveRight()
	{
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, -spinSpeed * Time.deltaTime);
	}


	private void moveLeft()
	{
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, spinSpeed * Time.deltaTime);
	}
}
