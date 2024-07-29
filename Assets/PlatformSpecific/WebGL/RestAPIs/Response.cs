public class ResponsePlayerInfoData
{
    public bool success;
    public PlayerInfoData result;
    public string code;
    public string message;
}

public class ResponseCreateData
{
    public bool success;
    public CreateInfoData result;
    public string code;
    public string message;
}

public class ResponseUpdateGameData
{
    public bool success;
    public UpdateInfoData result;
    public string code;
    public string message;
}

public class ResponseUpdatePlayerInfo
{
    public bool success;
    public UpdateInfoPlayer result;
    public string code;
    public string message;
}

public class ResponseEndGameData
{
    public bool success;
    public EndInfoData result;
    public string code;
    public string message;
}
public class ResponsePointHistoryGameData
{
    public bool success;
    public PointHistoryInfoData[] result;
    public string code;
    public string message;
}
public class ResponseCheckPlayDemoData
{
    public bool success;
    public CheckPlayDemoData result;
    public string code;
    public string message;
}
public class ResponseCheckPlayData
{
    public bool success;
    public CheckPlayData result;
    public string code;
    public string message;
}