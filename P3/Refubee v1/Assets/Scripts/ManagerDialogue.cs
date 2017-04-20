using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerDialogue : MonoBehaviour {

    public ManagerGame managerGame;
    public ManagerUI managerUI;
    public GameObject playerBee;
    public BeeScript beeScript;
    public Dialogue dialogue;
   
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public int answerNumber;
    public string something = "answer";
    public bool cinematicCamera;
    public bool playerIsPresentedAQuestion;
    public bool onetime;
    public bool secondtime;


    void Start()
    {
        managerGame = GameObject.FindGameObjectWithTag("GameController").GetComponent<ManagerGame>();
        managerUI = GameObject.FindGameObjectWithTag("GameController").GetComponent<ManagerUI>();

        playerBee = GameObject.FindGameObjectWithTag("Player");
        beeScript = playerBee.GetComponent<BeeScript>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC" && beeScript.beeInteract && dialogue == null)
        {
            dialogue = other.GetComponent<Dialogue>();                 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC" )
        {
            dialogue = null;           
        }
    }

    void Update()
    {
        if (dialogue == null)
        {
            answer1 = null;
            answer2 = null;
            answer3 = null;
            answer4 = null;
            cinematicCamera = false;
            playerIsPresentedAQuestion = false;
        }
    }
    
    void LateUpdate()
    {
        if (dialogue != null)
        {
            if (dialogue.questions[dialogue.entryPoint] == "I have just spawned one...")
            {
                if (!onetime)
                {
                    managerGame.SpawnSomePickUpsForBlueNPC();
                    onetime = true;
                }
            }

            if (dialogue.questions[dialogue.entryPoint] == "!!!END GAME!!!")
            {
                if (true)
                {
                    managerGame.EndGame();
                    
                }
            }
            if (dialogue.questions[dialogue.entryPoint] == "EXIT")
            {
                dialogue = null;
            }

            if (dialogue.questions[dialogue.entryPoint] == "I have just spawned a tree right next to you.")
            {
                if (!secondtime)
                {
                    managerGame.SpawnTreeForGroenLinksSupporter();
                    secondtime = true;
                }

            }

            if (dialogue.questions[dialogue.entryPoint] == "I have just spawned a tree right next to you.")
            {
                if (!secondtime)
                {
                    managerGame.SpawnTreeForGroenLinksSupporter();
                    secondtime = true;
                }

            }
        }








        if (dialogue != null)
        {
            cinematicCamera = true;
            question = dialogue.questions[dialogue.entryPoint];

            
            if (dialogue.questions[dialogue.entryPoint].All(char.IsDigit))
            {                
                dialogue.entryPoint = int.Parse(dialogue.questions[dialogue.entryPoint]);
            }

            if (dialogue.questions[dialogue.entryPoint] == "???")
            {
                answer1 = dialogue.questions[dialogue.entryPoint + 1];
                answer2 = dialogue.questions[dialogue.entryPoint + 2];
                answer3 = dialogue.questions[dialogue.entryPoint + 3];
                answer4 = dialogue.questions[dialogue.entryPoint + 4];
                playerIsPresentedAQuestion = true;
            }
            else
            {
                answer1 = null;
                answer2 = null;
                answer3 = null;
                answer4 = null;
                playerIsPresentedAQuestion = false;
            }

            if (beeScript.beeInteract && dialogue != null && dialogue.questions[dialogue.entryPoint] != "???")
            {
                dialogue.entryPoint++;

             
                if (dialogue.entryPoint >= dialogue.questions.Count)
                {
                    dialogue.entryPoint = 0;
                    
                }
            }
        }
    }
}
