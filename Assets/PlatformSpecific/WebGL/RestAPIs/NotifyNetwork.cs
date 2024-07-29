using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifyNetwork : MonoBehaviour
{
    [SerializeField] private Notify[] notifies;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    private float durationFlash = .5f;
    private float timer;
    bool fadeIn = false;
    bool fadeOut = true;
    // Start is called before the first frame update
    void Start()
    {
        timer = durationFlash;
    }

    private void Update()
    {
        if (!fadeIn)
            timer -= Time.deltaTime;
        else if (!fadeOut)
            timer += Time.deltaTime;

        if (timer < 0)
        {
            fadeOut = false;
            fadeIn = true;
        }
        else if (timer > durationFlash)
        {
            fadeIn = false;
            fadeOut = true;
        }
        image.color = new Color(1f, 1f, 1f, timer / durationFlash);
    }

    public void SetUp(string message, TypeNoti type = TypeNoti.NONE)
    {
        text.text = message;
        if (type == TypeNoti.NONE)
        {
            image.gameObject.SetActive(false);
            text.color = Color.white;
        }
        else
        {
            foreach (var item in notifies)
            {
                if (item.typeNoti == type)
                {
                    image.sprite = item.image;
                    text.color = item.color;
                    image.gameObject.SetActive(true);
                    break;
                }
            }
        }
        gameObject.SetActive(true);
    }
}

public enum TypeNoti
{
    NONE,
    ERROR,
    WARNING,
    INFO,
    NETWORK_ERROR
}

[Serializable]
public class Notify
{
    public Sprite image;
    public TypeNoti typeNoti;
    public Color color;
}
