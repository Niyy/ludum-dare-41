using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {


    public float movespeed = 20.0f;
    public Rigidbody2D rb;


    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update ()
    {

        // makse player watch mosue 
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movedir = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.AddForce(movedir * movespeed);




    }
    void OnTriggerEnter(Collider hurdle)

    {
        Debug.Log("helkp");
        if (hurdle.gameObject.tag == "wall")
        {
            rb.velocity = new Vector2(0, 0);
        }

    }
}
