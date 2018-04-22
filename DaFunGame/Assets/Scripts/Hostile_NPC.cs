using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_NPC : MonoBehaviour 
{
	public float walkSpeed;


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
		npcRB.AddForce(Vector2 * walkSpeed);
	}
}
