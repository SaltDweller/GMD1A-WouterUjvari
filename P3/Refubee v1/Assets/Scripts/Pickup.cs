using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int amountOfPointsThisPickUpAwardsUponPickingUp = 1;
    public int amountOfHealthThisPickUpAwardsUponPickingUp = 1;
    
    public float rotationSpeed = 5;
    public enum PickupType {score, health }
    public PickupType pickupType;


    public GameObject playerBee;
    public ManagerGame managerGame;
    public ManagerSound managerSound;

    void Start()
    {
        playerBee = GameObject.FindGameObjectWithTag("Player");
        managerGame = GameObject.Find("BossObject").GetComponent<ManagerGame>();
        managerSound = GameObject.Find("SoundBoss").GetComponent<ManagerSound>();

    }

    void FixedUpdate()
    {
        if (pickupType == PickupType.score)
        {
            transform.Rotate(rotationSpeed, rotationSpeed * 0.5f, 0);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(pickupType == PickupType.score)
            {
                managerGame.IncreaseScore(amountOfPointsThisPickUpAwardsUponPickingUp);
                managerSound.SoundPickUp();
                gameObject.SetActive(false);
                
            }
            else if(pickupType == PickupType.health && playerBee.GetComponent<BeeScript>().beeHealth <= 2)
            {
                gameObject.SetActive(false);
                managerGame.IncreaseHealth(amountOfHealthThisPickUpAwardsUponPickingUp);
                managerSound.SoundPickUp();
            }          
            
        }
    }
}
