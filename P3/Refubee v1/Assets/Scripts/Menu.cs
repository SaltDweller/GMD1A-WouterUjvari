using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Menu : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource movieAudio;

    void Start()
    {
        GameObject.Find("MovieScreen").GetComponent<RawImage>().texture = movie as MovieTexture;
        movieAudio = GameObject.Find("MovieScreen").GetComponent<AudioSource>();
        movieAudio.clip = movie.audioClip;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Hive");
        
    }

    public void PlayMovie()
    {
        GameObject.Find("MovieScreen").GetComponent<RawImage>().color = new Color(255, 255, 255, 1);
        movie.Play();
        movieAudio.Play();
        print("Test");
        GameObject.Find("MenuBee").GetComponent<AudioSource>().Stop();
        GameObject.Find("Knoppie1").GetComponent<Image>().color = new Color(255, 255, 255, 0.1f);
        GameObject.Find("Knoppie2").GetComponent<Image>().color = new Color(255, 255, 255, 0.1f);
        GameObject.Find("Knoppie3").GetComponent<Image>().color = new Color(255, 255, 255, 0.1f);

        //GameObject.Find("BeeHeart3").GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);


    }
}
