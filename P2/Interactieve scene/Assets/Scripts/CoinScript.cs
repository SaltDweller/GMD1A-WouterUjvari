using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    //Coin goes spin.
    void FixedUpdate () {
        transform.Rotate(Vector3.right);
        transform.Rotate(Vector3.up * 0.5f);        
    }
}
