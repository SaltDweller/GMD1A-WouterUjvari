using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    //Bunch of simple things.
    public float movementSpeed = 10;
    public float mouseSensitivity = 5.0f;
    public float upDownRange = 60.0f;
    float verticalRotation = 0;
    public float jumpSpeed = 5.0f;
    float verticalVelocity = 0;
    CharacterController characterController;
    
    //A ghetto way of raycasting.
    public GameObject crosshair;
    public static bool interacting;
   
    void Start()
    {       
        characterController = GetComponent<CharacterController>();
    }
   
    void Update()
    {
        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;      
        characterController.Move(speed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            verticalVelocity = jumpSpeed;
            Debug.Log("jump");
        }

        //Swing
        if (Input.GetButtonDown("Fire1"))
        {
            //meh
        }

        //grab
        if (Input.GetButton("Interact"))
        {
            Debug.Log("Interacting");
            interacting = true;
        }
        else
        {
            interacting = false;
        }


    }

    //Detects coins and finishline.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ManagerScript.score++;
            Debug.Log("Coin ");
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Finish"))
        {           
            Debug.Log("finish ");
            ManagerScript.grats = "Congrats! Use alt f4 as a reward!";
        }
    }

}