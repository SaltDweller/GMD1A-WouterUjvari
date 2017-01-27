using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour {

    //Manager can manipulate the walls.
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    //Message that gets filled when player reaches exit.
    public static string grats;

    //Number that represents the players score, displayed top right.
    public static int score;

    //String that represents the difficulty.
    public static string wallname = "low";

    //A list of bools that each represent a different wall height.
    public List<bool> wallheight = new List<bool>();

    //Used in a loop to keep looping.
    public static int playerCount;

    //Location at which the player is spawned.
    public Transform player;

    //How many players should spawn (very buggy).
    public static int amountOfPlayersPlaying = 1;
    
    //Magic that makes sure the manager always knows who he is.
    private static ManagerScript _instance;

    public static ManagerScript Instance               
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<ManagerScript>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        Cursor.visible = false;    
    }

    //Spawns a player prefab.
    void SpawnPlayer()
    {
        Instantiate(player, (transform.localPosition), Quaternion.identity);
    }

    //Ghetto UI
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Coins Collected: " + score);
        GUI.Label(new Rect(10, 50, 100, 100), "Amount of players: " + playerCount);
        GUI.Label(new Rect(10, 100, 100, 100), "Difficulty: (Press H to change): " + wallname);
        GUI.Label(new Rect(10, 150, 100, 100), "Pick crates with E from blue container");
        GUI.Label(new Rect(10, 200, 100, 100), grats);
    }

    void FixedUpdate()
    {
        //A loop that loops until the desired amount of players is spawned.
        while (playerCount < amountOfPlayersPlaying)
        {
            playerCount++;
            SpawnPlayer();
            Debug.Log("Amount of players: " + playerCount);
        }



    }

    void Update()
    {
        //Raises the walls according to the difficulty.
        if (Input.GetButtonDown("wallheight") && wallheight[0] == true)
        {
            wallheight[1] = true;
            wallheight[0] = false;
            wallname = "high";
        }
        else if (Input.GetButtonDown("wallheight") && wallheight[1] == true)
        {
            wallheight[2] = true;
            wallheight[1] = false;
            
            wallname = "really high";
        }
        else if (Input.GetButtonDown("wallheight") && wallheight[2] == true)
        {
            wallheight[0] = true;
            wallheight[2] = false;
            
            wallname = "low";
        }
        if (wallheight[0] == true)
        {
            wall1.transform.position = new Vector3(16, -1, -7);
            wall2.transform.position = new Vector3(32, 0, -7);
            wall3.transform.position = new Vector3(51, 1, -7);
        }

        if (wallheight[1] == true)
        {
            wall1.transform.position = new Vector3(16, 2, -7);
            wall2.transform.position = new Vector3(32, 3, -7);
            wall3.transform.position = new Vector3(51, 4, -7);
        }

        if (wallheight[2] == true)
        {
            wall1.transform.position = new Vector3(16, 5, -7);
            wall2.transform.position = new Vector3(32, 6, -7);
            wall3.transform.position = new Vector3(51, 7, -7);
        }
    }
}
