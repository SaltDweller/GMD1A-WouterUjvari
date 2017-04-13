using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour {

    public ManagerGame managerGame;
    public ManagerDialogue managerDialogue;
    public GameObject playerBee;
    public BeeScript beeScript;
    public Canvas canvas;
    public Text text;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public GameObject score;

    void Start()
    {
        managerGame = gameObject.GetComponent<ManagerGame>();
        managerDialogue = GameObject.FindGameObjectWithTag("Player").GetComponent<ManagerDialogue>();
        playerBee = GameObject.FindGameObjectWithTag("Player");
        beeScript = playerBee.GetComponent<BeeScript>();
        canvas = GameObject.FindGameObjectWithTag("CanvasTag").GetComponent<Canvas>();
        text = GameObject.FindGameObjectWithTag("CanvasTextTag").GetComponent<Text>();
        score = GameObject.Find("Score");

        button1 = GameObject.FindGameObjectWithTag("Button1Tag").GetComponent<Button>();
        button2 = GameObject.FindGameObjectWithTag("Button2Tag").GetComponent<Button>();
        button3 = GameObject.FindGameObjectWithTag("Button3Tag").GetComponent<Button>();
        button4 = GameObject.FindGameObjectWithTag("Button4Tag").GetComponent<Button>();

        button1.onClick.AddListener(Skip5);
        button2.onClick.AddListener(Skip7);
        button3.onClick.AddListener(Skip9);
        button4.onClick.AddListener(Skip11);

    }

    public void PauseMenuOn()
    {
        GameObject.Find("GreyPanel").GetComponent<Image>().enabled = true;
        GameObject.Find("PausedText").GetComponent<Text>().enabled = true;
    }

    public void PauseMenuOff()
    {
        GameObject.Find("GreyPanel").GetComponent<Image>().enabled = false;
        GameObject.Find("PausedText").GetComponent<Text>().enabled = false;
    }

    public void Skip5()
    {
        managerDialogue.dialogue.entryPoint = managerDialogue.dialogue.entryPoint + 5;
    }

    public void Skip7()
    {
        managerDialogue.dialogue.entryPoint = managerDialogue.dialogue.entryPoint + 7;
    }

    public void Skip9()
    {
        managerDialogue.dialogue.entryPoint = managerDialogue.dialogue.entryPoint + 9;
    }

    public void Skip11()
    {
        managerDialogue.dialogue.entryPoint = managerDialogue.dialogue.entryPoint + 11;
    }

    void Update()
    {
        score.GetComponent<Text>().text = managerGame.playerScore.ToString();

        if(beeScript.beeHealth == 0)
        {
            GameObject.Find("BeeHeart1").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            GameObject.Find("BeeHeart2").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            GameObject.Find("BeeHeart3").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        }

        else if (beeScript.beeHealth == 1)
        {
            GameObject.Find("BeeHeart1").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("BeeHeart2").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            GameObject.Find("BeeHeart3").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        }

        else if (beeScript.beeHealth == 2)
        {
            GameObject.Find("BeeHeart1").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("BeeHeart2").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("BeeHeart3").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        }

        else if (beeScript.beeHealth == 3)
        {
            GameObject.Find("BeeHeart1").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("BeeHeart2").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
            GameObject.Find("BeeHeart3").GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        }

        text.text = managerDialogue.question;

        if (text.text == "???")
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            text.gameObject.SetActive(true);
        }

        if (managerDialogue.dialogue == null)
        {
            text.text = null;
        }
        if (managerDialogue.answer1 != null)
        {
            button1.gameObject.SetActive(true);
            button1.GetComponentInChildren<Text>().text = managerDialogue.answer1;
        }
        else 
        {
            button1.gameObject.SetActive(false);

        }

        if (managerDialogue.answer2 != null)
        {
            button2.gameObject.SetActive(true);
            button2.GetComponentInChildren<Text>().text = managerDialogue.answer2;
        }
        else
        {
            button2.gameObject.SetActive(false);
        }

        if (managerDialogue.answer3 != null)
        {
            button3.gameObject.SetActive(true);
            button3.GetComponentInChildren<Text>().text = managerDialogue.answer3;
        }
        else
        {
            button3.gameObject.SetActive(false);
        }

        if (managerDialogue.answer4 != null)
        {
            button4.gameObject.SetActive(true);
            button4.GetComponentInChildren<Text>().text = managerDialogue.answer4;
        }
        else
        {
            button4.gameObject.SetActive(false);
        }

        if (button1.GetComponentInChildren<Text>().text == "")
        {
            button1.gameObject.SetActive(false);
        }

        if (button2.GetComponentInChildren<Text>().text == "")
        {
            button2.gameObject.SetActive(false);
        }

        if (button3.GetComponentInChildren<Text>().text == "")
        {
            button3.gameObject.SetActive(false);
        }

        if (button4.GetComponentInChildren<Text>().text == "")
        {
            button4.gameObject.SetActive(false);
        }
    }   
}
