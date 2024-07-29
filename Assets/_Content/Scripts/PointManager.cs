using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance {  get; private set; }
    public int point = 0;
    public int bestPoint;

    public int maxMiss;

    public int small;
    public int medium;
    public int large;

    public int currentLevel;


    // best point for size boardv 
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        maxMiss = 5;
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if(point <300)
        {
            maxMiss = 5;
        }
        if(point >= 300 && point<500)
        {
            maxMiss = 4;
        }
        if(point >= 500 && point<1000)
        {
            maxMiss = 3;
        }
        if (point >= 1000 && point<2000)
        {
            maxMiss = 2;
        }
        if (point >= 2000)
        {
            maxMiss = 1;
        }
    }
    public void SetUpBestPoint()
    {
        small = PlayerPrefs.GetInt("small");
        medium = PlayerPrefs.GetInt("medium");
        large = PlayerPrefs.GetInt("large");
    }
    public void AddPoint(int value,int x = 1)
    {   
        point += (value * x);
        if (point >= 100000)
            point = 100000;
    }

    public void SetRecord(int value)
    {
        int level = currentLevel;
        switch (level)
        {
            case 0:
                small = value;
                break;
            case 1:
                medium = value; break;
            case 2:
                large = value; break;
        }
        if (NetworkManager.instance.authData == null) return;
        if(NetworkManager.instance.authData.GetIsDemo())
        {
            switch (level)
            {
                case 0:
                    PlayerPrefs.SetInt("small",value); break;
                case 1:
                    PlayerPrefs.SetInt("medium", value); break;
                case 2:
                    PlayerPrefs.SetInt("large", value); break;
            }
        }
    }
}
