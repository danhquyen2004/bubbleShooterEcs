using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance {  get; private set; }
    public int point = 0;
    public int bestPoint;

    public int maxMiss;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        SetUpBestPoint();
        maxMiss = 5;
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
        bestPoint = PlayerPrefs.GetInt("BestPoint");
    }
    public void AddPoint(int value,int x = 1)
    {   
        point += (value * x);
        if (point >= 100000)
            point = 100000;
    }
}
