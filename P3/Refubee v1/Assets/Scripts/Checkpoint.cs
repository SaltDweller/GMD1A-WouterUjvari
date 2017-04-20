using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public BeeScript beeScript;
    public ManagerGame managerGame;

    void Start()
    {
        beeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BeeScript>();
        managerGame = GameObject.Find("BossObject").GetComponent<ManagerGame>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" )
        {
            print("CheckpointActivated!");
            managerGame.currentCheckPoint = this.gameObject;
        }
    }
}
