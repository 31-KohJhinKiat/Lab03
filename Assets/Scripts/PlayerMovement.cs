using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    private int coin1Count = 4;
    private int coin2Count = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coin1Count == 0)
        {
            SceneManager.LoadScene("GamePlay_Level2");
        }
        if (coin2Count == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
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
        if(collision.gameObject.tag.Equals("coin1"))
        {
            coin1Count--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("coin2"))
        {
            coin2Count--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("hazardWall"))
        {
            print("game over");
            SceneManager.LoadScene("LoseScene");
        }
    }

}
