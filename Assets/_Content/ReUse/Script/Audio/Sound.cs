using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource pop;
    public AudioSource gameOver;
    public AudioSource winSound;
    public AudioSource button;
    private void Reset()
    {
        pop = transform.Find("Pop").GetComponent<AudioSource>();
        gameOver = transform.Find("GameOver").GetComponent<AudioSource>();
        winSound = transform.Find("Win").GetComponent<AudioSource>();
        button = transform.Find("Button").GetComponent<AudioSource>();
    }
    public void Play_GameOver()
    {
        gameOver.Play();
    }
    public void Play_NewBest()
    {
        winSound.Play();
    }
    public void Play_Button()
    {
        button.Play();
    }
    public void Play_pop()
    {
        pop.Play();
    }
    public void SoundOff()
    {
        pop.volume = 0;
        gameOver.volume = 0;
        winSound.volume = 0;
        button.volume = 0;
    }
    public void SoundOn()
    {
        pop.volume = 1;
        gameOver.volume = 1;
        winSound.volume = 1;
        button.volume = 1;
    }
}
