using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCamera : MonoBehaviour {

    public GameObject cameraStandPlayerCinematic;
    public GameObject cameraStandNPC;
    public GameObject playerCamera;
    public GameObject playerBee;
    


    public enum CameraPosition { CameraStandPlayerCinematic, Default, CameraStandNPC };
    public CameraPosition cameraPosition;

    void Start()
    {
        cameraStandPlayerCinematic = GameObject.Find("CameraStandPlayerCinematic");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerBee = GameObject.FindGameObjectWithTag("Player");       
    }

    void LateUpdate()
    {
        if (cameraPosition == CameraPosition.CameraStandPlayerCinematic)
        {
            playerCamera.transform.position = cameraStandPlayerCinematic.transform.position;
            playerCamera.transform.rotation = cameraStandPlayerCinematic.transform.rotation;
        }

        if (cameraPosition == CameraPosition.CameraStandNPC)
        {
            playerCamera.transform.position = cameraStandNPC.transform.position;
            playerCamera.transform.rotation = cameraStandNPC.transform.rotation;
        }
    }

    void Update()
    {
        if ( playerBee.GetComponent<ManagerDialogue>().playerIsPresentedAQuestion)
        {
            cameraPosition = CameraPosition.CameraStandPlayerCinematic;
        }
        else
        {
            cameraPosition = CameraPosition.Default;
        }

        if (playerBee.GetComponent<ManagerDialogue>().cinematicCamera && !playerBee.GetComponent<ManagerDialogue>().playerIsPresentedAQuestion)
        {
            cameraStandNPC = playerBee.GetComponent<ManagerDialogue>().dialogue.gameObject.transform.GetChild(0).gameObject;
            cameraPosition = CameraPosition.CameraStandNPC;
        }
    }

}
