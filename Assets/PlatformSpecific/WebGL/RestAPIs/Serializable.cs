using System;

[Serializable]
public class PlayerInfoData
{
    public string msisdn;
    public string gameCode;
    public string playerOption;
    public int currentLevel;
    public float point;
    public int turn;
    public int coinGame;
}

[Serializable]
public class CreateInfoData
{
    public string sessionId;
    public string msisdn;
    public string gameCode;
    public float totalPoint;
    public string p1;
}

[Serializable]
public class UpdateInfoData
{
    public int id;
    public string msisdn;
    public string gameCode;
    public float point;
    public string createdAt;
    public string updatedAt;
}
[Serializable]
public class UpdateInfoPlayer
{
    public int id;
    public string msisdn;
    public int level;
    public string currentGameId;
    public string gameCode;
    public string playerOption;
    public string createdAt;
    public string updatedAt;
}

[Serializable]
public class EndInfoData
{
    public string id;
    public string msisdn;
    public string gameCode;
    public float totalPoint;
    public string beginTime;
    public string endTime;
}
[Serializable]
public class PointHistoryInfoData
{
    public int id;
    public string msisdn;
    public string gameCode;
    public float point;
    public int level;
    public string createdAt;
    public string updatedAt;
}

[Serializable]
public class CheckPlayDemoData
{
    public bool canPlay;
    public string fromTime;
    public string toTime;
    public string ip;
}
[Serializable]
public class CheckPlayData
{
    public bool canPlay;
    public string playType;
    public string usedPack;
    public int turn;
    public string fromTime;
    public string toTime;
    public int expiryDay;
}
[Serializable]
public class MapValue
{
    public int level;
    public int coin;
    public float point;

    public MapValue()
    {

    }
    public MapValue(int level, int coin, float point)
    {
        this.level = level;
        this.coin = coin;
        this.point = point;
    }
}