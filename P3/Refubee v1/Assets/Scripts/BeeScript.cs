using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour {

    public bool beeWalking;
    public bool beeRunning;
    public bool beeJumping;
    public bool beeLanding;
    public bool beeStanding;
    public bool beeFacingLeft;
    public bool beeInteract;
    public ManagerDialogue managerDialogue;
    public ManagerCamera managerCamera;
    public ManagerGame managerGame;
    public Animator anim;
    public float cameraDistance;
    public float cameraDistanceCinematic;
    public float cameraVerticalOffset;
    public float cameraCinematicAngle;
    public float velocity;
    public int beeHealth;
    public GameObject playerCamera;
    public float speedModifier;
    public Rigidbody rb;

    

    public ManagerSound managerSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        managerDialogue = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagerDialogue>();
        managerCamera = GameObject.Find("BossObject").GetComponent<ManagerCamera>();
        managerGame = GameObject.Find("BossObject").GetComponent<ManagerGame>();
        //particle = GameObject.FindGameObjectWithTag("Dust").GetComponent<ParticleSystem>();
    }

    void Awake()
    {
        beeHealth = 3;
    }

    void LateUpdate()
    {
        if (managerCamera.cameraPosition == ManagerCamera.CameraPosition.Default)
        {
            playerCamera.transform.position = transform.position + Vector3.back * cameraDistance + Vector3.up * cameraVerticalOffset;
            playerCamera.transform.rotation = Quaternion.identity;
        }           
    }

    void FixedUpdate()
    {
        velocity = rb.velocity.y;
        anim.SetFloat("pBeeVelocity", velocity);
        float horizontal = Input.GetAxis("Horizontal") * 0.1f * speedModifier;
        float vertical = Input.GetAxis("Vertical") * 0.1f * speedModifier;
        transform.Translate(horizontal, 0, 0 * Time.deltaTime, Space.World);

        if (vertical < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        }


        if (horizontal != 0 && beeStanding )
        {
            beeWalking = true;
            anim.SetBool("pBeeWalking", true);           
        }
        else
        {          
            beeWalking = false;
            anim.SetBool("pBeeWalking", false);
        }      
    }

    void Update()
    {


        if(beeHealth <= 0)
        {
            ReSpawnAtLatestCheckpoint();
            
        }

        if (Input.GetButtonDown("Jump") && beeStanding)
        {
            beeJumping = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 2500);
            anim.SetTrigger("pBeeJumping");
            beeStanding = false;
            managerSound.SoundPlayJump();
        }

        if (Input.GetButtonDown("Interact") && beeStanding)
        {
            beeInteract = true;
        }
        else
        {
            beeInteract = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "NPC")
        {
            beeStanding = true;
            beeJumping = false;
            anim.SetTrigger("pBeeLanding");
            anim.SetBool("pBeeStanding", true);
            managerSound.SoundPlayland();
        }

        if (other.tag == "Void")
        {
            ReSpawnAtLatestCheckpoint();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "NPC")
        {
            beeStanding = false;
            anim.SetBool("pBeeStanding", false);
        }
    }

    public void Hurt()
    {
        beeHealth--;
        managerSound.SoundPlayAU();     
    }
    
    public void ReSpawnAtLatestCheckpoint()
    {
        transform.position = managerGame.currentCheckPoint.transform.position;
        beeHealth = 3;
        managerSound.SoundPlayAU();
    }


}
