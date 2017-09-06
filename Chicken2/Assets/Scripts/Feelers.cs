using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feelers : MonoBehaviour {

    public bool meh;

    void OnTriggerStay(Collider other)
    {
        if ( other.GetComponent<Collider>().tag != "Player")
        {
            meh = true;
            print("test");
        }                
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag != "Player")
        {
            meh = false;
            print("test");
        }
    }


}
