using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float jumpheight = 10f;
    public float movespeed = 6f;
    public float sprintspeed;

    private float yspeed;
    private float directionY;

    public CharacterController controller;
    

    public bool isSprinting = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float Hmov = Input.GetAxis("Horizontal");
        float Vmov = Input.GetAxis("Vertical");

        Vector3 move = transform.right * Hmov + transform.forward * Vmov;

        yspeed += Physics.gravity.y * Time.deltaTime;


        // jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded )
        {
            yspeed = jumpheight;
        }

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            
        }
        else
        {
            isSprinting = false;
           

        }
        if (isSprinting == true)
        {
          move *=  sprintspeed;
          
        }

        Vector3 velocity = move * movespeed ;
        velocity.y = yspeed;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
