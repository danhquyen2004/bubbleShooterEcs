using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int missCount;
    public bool gameOver;
    private void Awake()
    {
        instance = this;
        missCount = 0;
        gameOver = false;
    }
}
