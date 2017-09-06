using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController myController;

    public float speed = 1.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public GameObject characterModel;
    private Vector3 moveDirection = Vector3.zero;



    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(-vertical * 0.1f * speed, 0, horizontal * 0.1f * speed, Space.World);
        
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButton("Jump"))
            {               
                moveDirection.y = jumpSpeed;
            }               
        }
        if (!controller.isGrounded)
        {           
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        controller.Move(moveDirection * Time.deltaTime);

        Vector3 NextDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (NextDir != Vector3.zero)
        {
            characterModel.transform.rotation = Quaternion.Slerp(characterModel.transform.rotation, Quaternion.LookRotation(NextDir.normalized), 0.15F);
        }
    }


}
