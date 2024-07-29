public class RequestParam
{
    public string name;
    public string value;
}
public class RequestBody
{
    public string msisdn;
    public string gameCode;
}

public class RequestBodyUpdateLevel
{
    public string msisdn;
    public string gameCode;
    public string sessionId;
    public MapValue mapValue;
    public string t;
}
public class RequestBodyUpdatePlayerInfo
{
    public string msisdn;
    public string gameCode;
    public string playerOption;
    public int coin;
}

public class RequestBodyEndGame
{
    public string msisdn;
    public string gameCode;
    public string sessionId;
    public bool isWin;
}
