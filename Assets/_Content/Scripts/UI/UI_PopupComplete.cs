using System;
using System.Drawing;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class UI_PopupComplete : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private void OnEnable()
    {
        AudioController.Instance.sound.Play_GameOver();
        score.text = PointManager.Instance.point.ToString();
        WebUpdate(PointManager.Instance.point);
        NewRecord();
    }

    private void NewRecord()
    {
        int currentRecord = PointManager.Instance.bestPoint;
        if (currentRecord < 0 || currentRecord < PointManager.Instance.point)
        {
            PointManager.Instance.SetRecord(PointManager.Instance.point);
        }
    }

    private void WebUpdate(int point)
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            MapValue mapValue =
                new MapValue(PointManager.Instance.currentLevel, 0,point);
            Platform.PlatformService.UpdateGame(mapValue);
        }
    }
}
