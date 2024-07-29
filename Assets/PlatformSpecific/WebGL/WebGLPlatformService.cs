using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLPlatformService : IPlatformService
{
    public void CheckDemoPlayAvailable()
    {

    }

    public void CheckPlayAvailable()
    {
        if (NetworkManager.instance != null)
            NetworkManager.instance.CheckAvailablePlay();
    }

    public void CreateGame()
    {
        if (NetworkManager.instance != null)
        {
            NetworkManager.instance.StartGame();
        }

    }

    public void EndGame(bool isWin)
    {
        if (NetworkManager.instance != null)
        {
            NetworkManager.instance.EndGame(isWin);
        }
    }

    public void GetHistoryGame()
    {
    }

    public void GetInfoPlayer()
    {
    }

    public void UpdateGame(MapValue mapValue)
    {
        if (NetworkManager.instance != null)
        {
            NetworkManager.instance.UpdatePoint(mapValue.level, (int)mapValue.point, 0);
        }

    }

    public void UpdatePlayerInfo(string playerInfo, int coin)
    {
    }
}
