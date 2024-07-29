using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicAndSoundButton : MonoBehaviour
{
    [SerializeField] bool isMusic;
    [SerializeField] Image icon;
    public Sprite toggleOn;
    public Sprite toggleOff;
    private void Update()
    {
        if (isMusic)
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
        if (AudioController.Instance.musicOff)
        {
            icon.sprite = toggleOff;
        }
        else
        {
            icon.sprite = toggleOn;
        }
    }
    public void SoundHandle()
    {
        if (AudioController.Instance.soundOff)
        {
            icon.sprite = toggleOff;
        }
        else
        {
            icon.sprite = toggleOn;
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
