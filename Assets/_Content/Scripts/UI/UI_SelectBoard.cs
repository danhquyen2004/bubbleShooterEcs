using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectBoard : MonoBehaviour
{
    [SerializeField] protected Config config;
    public void Btn_Small()
    {
        Platform.PlatformService.CreateGame();
        PointManager.Instance.currentLevel = 0;
        PointManager.Instance.bestPoint = PointManager.Instance.small;
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(7, 11);
        config._rowsMax = 9;
        SceneTransition.instance.LoadSceneByName("Game");
    }
    public void Btn_Medium()
    {
        Platform.PlatformService.CreateGame();
        PointManager.Instance.currentLevel = 1;
        PointManager.Instance.bestPoint = PointManager.Instance.medium;
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(9, 15);
        config._rowsMax = 13;
        SceneTransition.instance.LoadSceneByName("Game");
    }

    public void Btn_Large()
    {
        Platform.PlatformService.CreateGame();
        PointManager.Instance.currentLevel = 2;
        PointManager.Instance.bestPoint = PointManager.Instance.large;
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(11, 20);
        config._rowsMax = 18;
        SceneTransition.instance.LoadSceneByName("Game");
    }


}
