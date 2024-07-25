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
    }

    //private void NewRecord(string timer)
    //{
    //    int currentRecord = record.GetRecord(CurrentLevel.Instance.level);
    //    int newRecord = Record.ConvertToPoint(timer);
    //    if (currentRecord < 0 || currentRecord < newRecord)
    //    {
    //        levelOfDifficult.text = "NEW RECORD!";
    //        levelOfDifficult.color = Color.yellow;
    //        record.SetRecord(CurrentLevel.Instance.level, newRecord);
    //    }
    //}

    //private void WebUpdate(int point)
    //{
    //    if (Application.platform == RuntimePlatform.WebGLPlayer)
    //    {
    //        MapValue mapValue =
    //            new MapValue((int)CurrentLevel.Instance.level, point, 0);
    //        Platform.PlatformService.UpdateGame(mapValue);
    //    }
    //}
}
