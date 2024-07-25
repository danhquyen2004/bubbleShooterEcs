using System;
using System.Drawing;
using TMPro;
using UnityEngine;
using Color = UnityEngine.Color;

public class UI_PopupComplete : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelOfDifficult;
    //private void OnEnable()
    //{


    //    levelOfDifficult.text = CurrentLevel.Instance.level.ToString().ToUpper();
    //    switch (CurrentLevel.Instance.level)
    //    {
    //        case Level.beginner:
    //            levelOfDifficult.color = new Color(0, 0.6f, 1);
    //            break;
    //        case Level.easy:
    //            levelOfDifficult.color = new Color(0.1f, 0.8f, 0);
    //            break;
    //        case Level.medium:
    //            levelOfDifficult.color = new Color(0.7f, 0.8f, 0);
    //            break;
    //        case Level.hard:
    //            levelOfDifficult.color = new Color(1, 0, 0);
    //            break;
    //    }

    //    timer.text = UI_PanelFlag.instance.stopWatch.text;
    //    WebUpdate(Record.ConvertToPoint(timer.text));
    //    NewRecord(timer.text);
    //    timer.text = Record.ConvertToPoint(timer.text).ToString();
    //}

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
