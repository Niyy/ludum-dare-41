using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 5;
    private float inputValueY = 0;

    [SerializeField]
    private float mouseSpeed = 5;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputValueY = Input.GetAxis("Vertical");
    }

    void FixedUpdate ()
    {
        //Move Forward and back
        if(inputValueY != 0)
        {
            rb.AddForce((transform.up * inputValueY));
        }

        //Rotate left and right with mouse
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, mouseSpeed * Time.deltaTime);
    }
}
