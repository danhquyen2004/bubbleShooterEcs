using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private void Awake()
    {
        //Platform.Initialize();
        Application.targetFrameRate = 60;
    }
}
