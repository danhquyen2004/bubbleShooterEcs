using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

[RequireComponent(typeof(RestAPIs))]
public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public AuthenticationData authData;
    [HideInInspector] public string sessionId;
    [SerializeField] private RestAPIs restAPIs;
    private string publicKeyPEM;
    public bool canPlayDemo;

    [SerializeField] PointManager record;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Platform.Initialize();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        authData = restAPIs.receiveFromWeb._authenticationData;
        record = FindAnyObjectByType<PointManager>();
        if (authData != null)
        {
            if (authData.GetIsDemo())
            {
                CheckAvailablePlayDemo();
                PointManager.Instance.SetUpBestPoint();
            }
            else
            {
                CheckAvailablePlay();
                GetPointHistory();
            }
        }
    }

    void GetPlayerInfoResponse(ResponsePlayerInfoData _response)
    {
        if (_response != null)
        {
            Debug.Log(JsonUtility.ToJson(_response));
        }
    }

    void GetCreateResponse(ResponseCreateData _response)
    {
        if (_response != null)
        {
            var p1 = _response.result.p1;
            sessionId = _response.result.sessionId;
            publicKeyPEM = @"-----BEGIN PUBLIC KEY-----
{0}
-----END PUBLIC KEY-----";
            publicKeyPEM = string.Format(publicKeyPEM, p1);
            Debug.Log(publicKeyPEM);
            Debug.Log(p1);
        }
    }

    void GetUpdateResponse(ResponseUpdateGameData _response)
    {
        if (_response != null)
        {
            Debug.Log(_response.message);
            Platform.PlatformService.EndGame(false);
        }
    }
    void GetEndGameResponse(ResponseEndGameData _response)
    {
        if (_response != null)
        {
            Debug.Log(_response.message);
        }
    }

    void GetBestPoint(ResponsePointHistoryGameData _response)
    {
        if (_response != null)
        {
            Debug.Log(JsonUtility.ToJson(_response.result));
            foreach (var member in _response.result)
            {
                switch (member.level)
                {
                    case 0:
                        record.small = (int)member.point; break;
                    case 1:
                        record.medium = (int)member.point; break;
                    case 2:
                        record.large = (int)member.point; break;
                }
            }
        }

    }
    void CheckPlayDemo(ResponseCheckPlayDemoData _response)
    {
        if (_response != null)
        {
            Debug.Log(_response.message);
            canPlayDemo = _response.result.canPlay;
            if (!canPlayDemo)
            {
                restAPIs.notifyNetwork.SetUp("Your trial period has ended!", TypeNoti.WARNING);
            }
        }
    }
    void CheckPlay(ResponseCheckPlayData _response)
    {
        if (_response != null)
        {
            Debug.Log(_response.message);
            if (!_response.result.canPlay)
            {
                restAPIs.notifyNetwork.SetUp("Not enough energy! Go to STORE and buy now!", TypeNoti.ERROR);
            }
        }
    }
    public void CheckAvailablePlayDemo()
    {
        StartCoroutine(restAPIs.CheckAvailablePlayDemo("demo/api/player/check-ability-to-play-game", null, new RequestBody()
        {
            gameCode = authData.GetGameCode()
        }, CheckPlayDemo));
    }
    public void CheckAvailablePlay()
    {
        StartCoroutine(restAPIs.CheckAvailablePlay("api/player/check-ability-to-play-game", null, new RequestBody()
        {
            msisdn = authData.GetMsisdn()
        }, CheckPlay));
    }

    public void StartGame()
    {
        if (authData != null && !authData.GetIsDemo())
        {
            StartCoroutine(restAPIs.CreateGame("api/game/create", null, new RequestBody()
            {
                msisdn = authData.GetMsisdn(),
                gameCode = authData.GetGameCode(),
            }, GetCreateResponse));
        }
    }

    public void UpdatePoint(int level, int point, int coin)
    {
        if (authData != null && !authData.GetIsDemo())
        {
            string dataToEncrypt = $"{authData.GetMsisdn()}_&_&_{sessionId}_&_&_{authData.GetGameCode()}";
            Debug.Log(dataToEncrypt);
            string encryptString = EncryptCustom.Encrypt(dataToEncrypt, publicKeyPEM);

            StartCoroutine(restAPIs.UpdateGame("api/game/update-level", null, new RequestBodyUpdateLevel()
            {
                gameCode = authData.GetGameCode(),
                msisdn = authData.GetMsisdn(),
                sessionId = sessionId,
                mapValue = new MapValue()
                {
                    level = level,
                    point = point,
                    coin = coin
                },
                t = encryptString
            }, GetUpdateResponse));
        }
    }
    public void UpdatePlayerInfo(string playerInfo, int coin)
    {
        if (authData != null && !authData.GetIsDemo())
        {
            StartCoroutine(restAPIs.UpdatePlayerInfo("api/player", null, new RequestBodyUpdatePlayerInfo()
            {
                gameCode = authData.GetGameCode(),
                msisdn = authData.GetMsisdn(),
                coin = coin,
                playerOption = playerInfo
            }, GetUpdatePlayerInfoResponse));
        }
    }

    void GetUpdatePlayerInfoResponse(ResponseUpdatePlayerInfo _response)
    {
        if (_response != null)
        {
            Debug.Log(_response.result.playerOption);
        }
    }

    public void EndGame(bool isWin)
    {
        if (authData != null && !authData.GetIsDemo())
        {
            StartCoroutine(restAPIs.EndGame("api/game/end-game", null, new RequestBodyEndGame()
            {
                gameCode = authData.GetGameCode(),
                msisdn = authData.GetMsisdn(),
                sessionId = sessionId,
                isWin = isWin,
            }, GetEndGameResponse));
        }
    }
    public void GetPointHistory()
    {
        if (authData != null && !authData.GetIsDemo())
        {
            StartCoroutine(restAPIs.GetPointHistory("api/player/get-point-history", null, new RequestBody()
            {
                msisdn = authData.GetMsisdn(),
                gameCode = authData.GetGameCode(),
            }, GetBestPoint));
        }
    }

    public void GetPlayerInfo()
    {
        if (authData != null && !authData.GetIsDemo())
        {
            StartCoroutine(restAPIs.GetPlayerInfo("api/player/get-info", null, new RequestBody()
            {
                msisdn = authData.GetMsisdn(),
                gameCode = authData.GetGameCode(),
            }, GetPlayerInfoResponse));
        }
    }
}
