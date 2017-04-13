using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum Enemytype  {isFloatingEnemy, isFlyingEnemyHorizontal, isFlyingEnemyvertical, isStandingEnemy, isWalkingEnemy };
    public Enemytype enemyType;

    /*
    public bool isFloatingEnemy;
    public bool isFlyingEnemyHorizontal;
    public bool isFlyingEnemyvertical;
    public bool isStandingEnemy;
    public bool isWalkingEnemy;
    */

    public bool dead;
    public bool isFacingLeft;
    public bool playerOnHead;
    public bool playerOnBody;

    public bool canBeJumpedOn = true;
    public bool hasRange = true;
    public float range = 5;
    public float speed = 1;
    private float timer;
    private float deathTimer;
    public float bouncyness = 20;

    public GameObject playerBee;
    public ManagerGame managerGame;

    public BoxCollider head;
    public BoxCollider body;

    public ManagerSound managerSound;



    void Start()
    {
        managerSound = GameObject.Find("SoundBoss").GetComponent<ManagerSound>();
        playerBee = GameObject.FindGameObjectWithTag("Player");
        managerGame = GameObject.Find("BossObject").GetComponent<ManagerGame>();


        if ( enemyType == Enemytype.isFlyingEnemyHorizontal || enemyType == Enemytype.isFlyingEnemyvertical || enemyType == Enemytype.isFloatingEnemy)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }





    void FixedUpdate()
    {

        timer += Time.deltaTime;
        if (timer >= range && hasRange)
        {
            timer = 0;
            isFacingLeft = !isFacingLeft;
        }
        if (!dead)
        {
            if (isFacingLeft)
            {
                if (enemyType == Enemytype.isWalkingEnemy || enemyType == Enemytype.isFlyingEnemyHorizontal)
                {
                    transform.Translate(-0.05f * speed, 0, 0, Space.World);
                    transform.rotation = Quaternion.AngleAxis(-180, Vector3.up);
                }

                else if (enemyType == Enemytype.isFlyingEnemyvertical)
                {
                    transform.Translate(0, -0.05f * speed, 0, Space.World);
                }
            }

            if (!isFacingLeft)
            {
                if (enemyType == Enemytype.isWalkingEnemy || enemyType == Enemytype.isFlyingEnemyHorizontal)
                {
                    transform.Translate(0.05f * speed, 0, 0, Space.World);
                    transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                }
                else if (enemyType == Enemytype.isFlyingEnemyvertical)
                {
                    transform.Translate(0, 0.05f * speed, 0, Space.World);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !playerOnBody)
        {
            playerOnHead = true;
            dead = true;
            playerBee.GetComponent<Rigidbody>().velocity = new Vector3(0, bouncyness, 0);
            Die();

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnHead = false;

        }
    }
   

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && !playerOnHead)
        {
            playerOnBody = true;
            print("AU");
            
            body.size = new Vector3(4, 1, 4);
            playerBee.GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !playerOnHead)
        {
            playerBee.GetComponent<BeeScript>().Hurt();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnBody = false;
            body.size = new Vector3(1, 1, 1);
        }

    }




    void Die()
    {
        managerSound.SoundPlayAU();
        dead = true;
        managerGame.IncreaseScore(2);
        gameObject.SetActive(false);
        
        if (enemyType == Enemytype.isFloatingEnemy || enemyType == Enemytype.isFlyingEnemyHorizontal || enemyType == Enemytype.isFlyingEnemyvertical)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            
            
        }
    }

    
}
