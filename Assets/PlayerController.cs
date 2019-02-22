using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController: MonoBehaviour {
    Rigidbody rb;
    float jamp = 500.0f;
    public float speed = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&this.rb.velocity.y==0)
        {
            this.rb.AddForce(transform.up * this.jamp);
        }
        if (Input.GetKey("right"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }

}
