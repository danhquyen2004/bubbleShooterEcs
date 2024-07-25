using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;
    [SerializeField] Animator transitionAnim;
    private void Awake() {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        } 
        instance = this;
        transitionAnim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }


    public void LoadSceneByName(string nameScene)
    {
        StartCoroutine(LoadScene(nameScene));
    }
    IEnumerator LoadScene(string nameScene)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nameScene);
        transitionAnim.SetTrigger("Start");
    }

}
