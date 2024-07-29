using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventUI : MonoBehaviour
{
    public static EventUI Instance { get; private set; }
    public GameObject panelPause;
    public GameObject panelSelectBoard;
    public GameObject panelAudioSetting;


    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    public bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    private void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Btn_Home()
    {
        Platform.PlatformService.EndGame(false);
        AudioController.Instance.sound.Play_Button();
        SceneTransition.instance.LoadSceneByName("MainUI");
    }
    public void Btn_Quit()
    {
        AudioController.Instance.sound.Play_Button();
        SceneTransition.instance.LoadSceneByName("MainUI");
    }
    public void Btn_Play()
    {
        Platform.PlatformService.CreateGame();
        AudioController.Instance.sound.Play_Button();
        SceneTransition.instance.LoadSceneByName("Game");
    }
    public void Btn_OpenPanel(GameObject panel)
    {
        AudioController.Instance.sound.Play_Button();
        panel.SetActive(true);
    }
    public void Btn_ClosePanel(GameObject panel)
    {
        AudioController.Instance.sound.Play_Button();
        panel.SetActive(false);
    }
}
