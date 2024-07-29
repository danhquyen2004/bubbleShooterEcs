using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatformService
{
    void CreateGame();
    void UpdateGame(MapValue mapValue);
    void EndGame(bool isWin);
    void GetHistoryGame();
    void GetInfoPlayer();
    void CheckPlayAvailable();
    void CheckDemoPlayAvailable();
    void UpdatePlayerInfo(string playerInfo, int coin);
}
