using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    //If the players crosshair object collides with the object.
    public bool playerCanGrab;
      
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Crosshair")
        {
            Debug.Log("ready to grab");
            playerCanGrab = true;         
        }
    }
    //When the player looks away.
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Crosshair")
        {            
            playerCanGrab = false;           
        }
    }
	
	void Update ()
    {
        //Object follows the crosshair and stuff.
        if (Player.interacting == true && playerCanGrab == true)
        {          
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("CrosshairTag").transform.position, 1);
            GetComponent<Rigidbody>().useGravity = false;
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<MeshCollider>().enabled = true;
        }
    }
}
