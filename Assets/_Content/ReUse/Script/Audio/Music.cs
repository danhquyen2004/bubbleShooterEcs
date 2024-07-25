using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource music;
    private void Reset()
    {
        music = transform.Find("Music").GetComponent<AudioSource>();
    }
    public void Play_Music()
    {
        Invoke(nameof(Delay_Music), 1f);
    }
    public void Delay_Music()
    {
        music.Play();
    }
    public void Stop_Music()
    {
        music.Stop();
    }
    public void MusicOff()
    {
        music.volume = 0;
    }
    public void MusicOn()
    {
        music.volume = 0.2f;
    }
}
