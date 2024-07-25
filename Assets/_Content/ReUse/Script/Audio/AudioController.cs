using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    public Sound sound;
    public Music music;
    public bool soundOff;
    public bool musicOff;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sound = FindAnyObjectByType<Sound>();
        music = FindAnyObjectByType<Music>();
        musicOff = PlayerPrefs.GetInt("musicOff") == 1 ? true : false;
        soundOff = PlayerPrefs.GetInt("soundOff") == 1 ? true : false;
        LoadSettingAudio();

    }
    private void LoadSettingAudio()
    {
        if (musicOff)
        {
            music.MusicOff();
        }
        else
        {
            music.MusicOn();
        }
        if (soundOff)
        {
            sound.SoundOff();
        }
        else
        {
            sound.SoundOn();
        }
    }
    public void MusicHandle()
    {
        if (musicOff)
        {
            musicOff = false;
            music.MusicOn();
        }
        else
        {
            musicOff = true;
            music.MusicOff();
        }

        PlayerPrefs.SetInt("musicOff", musicOff ? 1 : 0);
    }
    public void SoundHandle()
    {
        if (soundOff)
        {
            soundOff = false;
            sound.SoundOn();
        }
        else
        {
            soundOff = true;
            sound.SoundOff();
        }
        PlayerPrefs.SetInt("soundOff", soundOff ? 1 : 0);
    }

}
