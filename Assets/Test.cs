using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Test : MonoBehaviour {
    // speedを制御する
    public float speed = 3.0f;
    public float a_speed = 1.0f;
    float moveX = 0f;
    float moveZ = 0f;
    float a_moveX = 0f;
    float a_moveZ = 0f;
    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 direction = new Vector3(moveX, 0, 0);

        a_moveX = Input.GetAxis("Horizontal") * a_speed;
        a_moveZ = Input.GetAxis("Vertical") * a_speed;
        Vector3 a_direction = new Vector3(a_moveX, 0, 0);

        controller.SimpleMove(direction);

        if (controller.isGrounded)
        { //地面についているか判定
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = 15; //ジャンプするベクトルの代入
            }
            
        }
        moveDirection.y -= 10 * Time.deltaTime; //重力計算
        controller.Move(moveDirection * Time.deltaTime); //cubeを動かす処理

        if (!controller.isGrounded)
        {
            Debug.Log("空中");
            controller.Move(a_direction);
        }

        if (transform.position.y < 0)
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
