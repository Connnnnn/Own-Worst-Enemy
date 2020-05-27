using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed=40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch=false;

    private void Start()
    {
        
    }
    void Update()
    {
        if (!controller.LevelIsOver)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
