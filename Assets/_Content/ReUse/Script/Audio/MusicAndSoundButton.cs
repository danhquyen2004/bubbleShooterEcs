using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndSoundButton : MonoBehaviour
{
    [SerializeField] bool isMusic;
    [SerializeField] GameObject xIcon;
    private void Update()
    {
        if(isMusic)
        {
            MusicHandle();
        }
        else
        {
            SoundHandle();
        }
    }
    public void MusicHandle()
    {
        if(AudioController.Instance.musicOff)
        {
            xIcon.SetActive(true);
        }
        else
        {
            xIcon.SetActive(false);
        }
    }
    public void SoundHandle()
    {
        if (AudioController.Instance.soundOff)
        {
            xIcon.SetActive(true);
        }
        else
        {
            xIcon.SetActive(false);
        }
    }

    public void Btn_Music()
    {
        AudioController.Instance.sound.Play_Button();
        AudioController.Instance.MusicHandle();
    }
    public void Btn_Sound()
    {
        AudioController.Instance.sound.Play_Button();
        AudioController.Instance.SoundHandle();
    }
}
