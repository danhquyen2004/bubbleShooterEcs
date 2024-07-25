using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectBoard : MonoBehaviour
{
    [SerializeField] protected Config config;
    public void Btn_Small()
    {
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(7, 11);
        config._rowsMax = 9;
        SceneTransition.instance.LoadSceneByName("Game");
    }
    public void Btn_Medium()
    {
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(9, 15);
        config._rowsMax = 13;
        SceneTransition.instance.LoadSceneByName("Game");
    }

    public void Btn_Large()
    {
        AudioController.Instance.sound.Play_Button();
        config._boardSize = new Vector2Int(11, 20);
        config._rowsMax = 18;
        SceneTransition.instance.LoadSceneByName("Game");
    }
}
