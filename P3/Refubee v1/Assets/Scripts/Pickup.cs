using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int amountOfPointsThisPickUpAwardsUponPickingUp = 1;
    public bool doesRotate = true;
    public float rotationSpeed = 5;

    public GameObject playerBee;
    public ManagerGame managerGame;

    void Start()
    {
        playerBee = GameObject.FindGameObjectWithTag("Player");
        managerGame = GameObject.Find("BossObject").GetComponent<ManagerGame>();
    }

    void FixedUpdate()
    {
        if (doesRotate)
        {
            transform.Rotate(rotationSpeed, rotationSpeed * 0.5f, 0);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            managerGame.IncreaseScore(amountOfPointsThisPickUpAwardsUponPickingUp);
            gameObject.SetActive(false);
        }
    }
}
