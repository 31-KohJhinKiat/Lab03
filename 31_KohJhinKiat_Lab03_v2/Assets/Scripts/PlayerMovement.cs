using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    { 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("coin"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("hazardWall"))
        {
            print("game over");
        }
    }

}
