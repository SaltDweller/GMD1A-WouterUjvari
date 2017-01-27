using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCrate : MonoBehaviour {

    //detects crosshair the same way as in InteractableObject.
    public bool playerCanGrab;
    public Transform objectCrate;   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Crosshair")
        {
            Debug.Log("ready to grab");
            playerCanGrab = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Crosshair")
        {
            playerCanGrab = false;
        }
    }

    void Update()
    {
        //Spawns a crate when player is looking & is close enough & presses E.
        if (Input.GetButtonDown("Interact") && playerCanGrab == true)
        {
            Instantiate(objectCrate, (transform.localPosition), Quaternion.identity);
        }

    }
}
