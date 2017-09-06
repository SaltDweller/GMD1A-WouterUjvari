using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public Animator anim;
    public CharacterController myController;

    public PlayerMovement playermovement;

    public float timer;
    public int randomEmote;

   
    void Update()
    {
        timer++;
        if ( timer >= 100)
        {
            randomEmote = Random.Range(0, 30);
            anim.SetInteger("pRandomEmote", randomEmote);
            
        }

        if ( timer >= 101)
        {
            randomEmote = 30;
            timer = 0;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("pWalk", true);
        }
        else
        {
            anim.SetBool("pWalk", false);
        }

        if (!myController.isGrounded)
        {
            anim.SetBool("bStanding", false);
            if (myController.velocity.y > 0)
            {
                {
                    anim.SetBool("bJump", true);
                }
            }
            else
            {
                anim.SetBool("bJump", false);
            }

            if ( myController.velocity.y < 0)
            {
                anim.SetBool("bFalling", true);
            }
            else
            {
                anim.SetBool("bFalling", false);
            }
        }
        else
        {
            anim.SetBool("bStanding", true);
        }
    }
}



