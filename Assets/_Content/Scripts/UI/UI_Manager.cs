using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScore;
    [SerializeField] TextMeshProUGUI score;

    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timer;
    private float startTime;
    private bool isRunning = false;

    [Header("Popup")]
    [SerializeField] GameObject gameOverPopup;
    private void Start()
    {
        //timer.text = "00:00.00";
        //StartTimer();

        if (bestScore!= null )
            bestScore.text = PointManager.Instance.bestPoint.ToString();
    }
    private void Update()
    {
        UpdatePoint();
        UpdateBestScore();
        //UpdateTimer();
        UpdatePopupPanel();
    }

    private void UpdatePoint()
    {
        if(score !=null)
            score.text = PointManager.Instance.point.ToString();
    }
    private void UpdateBestScore()
    {
        if (bestScore == null) return;
        if(PointManager.Instance.point >= Convert.ToInt32(bestScore.text))
        {
            bestScore.text = score.text;
        }
    }
    private void UpdateTimer()
    {
        if (isRunning)
        {
            float timeSinceStart = Time.time - startTime;
            string minutes = Mathf.Floor(timeSinceStart / 60).ToString("00");
            string seconds = (timeSinceStart % 60).ToString("00");

            timer.text = minutes + ":" + seconds;
        }

    }

    private void UpdatePopupPanel()
    {
        if(GameController.instance.gameOver)
        {
            StopTimer();
            gameOverPopup.SetActive(true);
        }
            
    }

    #region TimerHandle
    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        isRunning = false;
        timer.text = "00:00";
    }
    #endregion
}
