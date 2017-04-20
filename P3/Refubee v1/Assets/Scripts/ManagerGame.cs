using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour {

    public ManagerUI managerUI;
    public ManagerDialogue managerDialogue;
    public GameObject playerBee;
    public BeeScript beeScript;
    public ManagerCamera managerCamera;

    public GameObject orbitObject;
    public GameObject triple;
    public GameObject tree;
    public Material skyboxMat;
    public Quaternion sunAngle;
    public GameObject currentCheckPoint;
    public float smooth;
    public float rotation;
    public int timeOfDay;
    public int playerScore;

    public bool pauseGame = false;
    public bool showPauseGUI = false;
    


    void Start()
    {
        managerUI = gameObject.GetComponent<ManagerUI>();
        managerDialogue = gameObject.GetComponent<ManagerDialogue>();
        playerBee = GameObject.FindGameObjectWithTag("Player");
        beeScript = playerBee.GetComponent<BeeScript>();
        managerCamera = gameObject.GetComponent<ManagerCamera>();      
    }

    void FixedUpdate()
    {       
        orbitObject.transform.rotation = Quaternion.Slerp(transform.rotation, sunAngle, Time.deltaTime * smooth);
        rotation -= Time.deltaTime * 2;
        skyboxMat.SetFloat("_Rotation", rotation);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                Time.timeScale = 0;
                pauseGame = true;
                GameObject.FindWithTag("Player").GetComponent<BeeScript>().enabled = false;
                showPauseGUI = true;
            }
        }

        if (pauseGame == false)
        {
            Time.timeScale = 1;
            pauseGame = false;
            GameObject.FindWithTag("Player").GetComponent<BeeScript>().enabled = true;
            showPauseGUI = false;
        }

        if (showPauseGUI == true)
        {
            managerUI.PauseMenuOn();
        }
        else
        {
            managerUI.PauseMenuOff();
        }
    }

    public void IncreaseScore(int amount)
    {
        playerScore = playerScore + amount;
    }

    public void IncreaseHealth(int amount)
    {
        beeScript.beeHealth = beeScript.beeHealth + amount;
    }

    public void SpawnSomePickUpsForBlueNPC()
    {
        Instantiate(triple, new Vector3(-100, 235, 0), Quaternion.identity);
    }

    public void SpawnTreeForGroenLinksSupporter()
    {
        Instantiate(tree, new Vector3(8, 240, 0), Quaternion.identity);
    }

    public void EndGame()
    {
        Application.Quit();
        print("quit");

    }
}
