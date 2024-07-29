using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(ReceiveFromWeb))]
public class RestAPIs : MonoBehaviour
{
    public ReceiveFromWeb receiveFromWeb;
    public string hostApis;
    public static RestAPIs Singleton;
    public NotifyNetwork notifyNetwork;
    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    public IEnumerator GetPlayerInfo(string endPoint, RequestParam[] requestParams, RequestBody body, Action<ResponsePlayerInfoData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponsePlayerInfoData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }

    public IEnumerator CreateGame(string endPoint, RequestParam[] requestParams, RequestBody body, Action<ResponseCreateData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseCreateData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }

    public IEnumerator UpdateGame(string endPoint, RequestParam[] requestParams, RequestBodyUpdateLevel body, Action<ResponseUpdateGameData> callback)
    {
        yield return new WaitForSeconds(.2f);
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseUpdateGameData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
    public IEnumerator UpdatePlayerInfo(string endPoint, RequestParam[] requestParams, RequestBodyUpdatePlayerInfo body, Action<ResponseUpdatePlayerInfo> callback)
    {
        yield return new WaitForSeconds(.2f);
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "PUT")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseUpdatePlayerInfo>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
    public IEnumerator EndGame(string endPoint, RequestParam[] requestParams, RequestBodyEndGame body, Action<ResponseEndGameData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseEndGameData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
    public IEnumerator GetPointHistory(string endPoint, RequestParam[] requestParams, RequestBody body, Action<ResponsePointHistoryGameData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponsePointHistoryGameData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
    public IEnumerator CheckAvailablePlayDemo(string endPoint, RequestParam[] requestParams, RequestBody body, Action<ResponseCheckPlayDemoData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("ApiKey", $"{receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseCheckPlayDemoData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
    public IEnumerator CheckAvailablePlay(string endPoint, RequestParam[] requestParams, RequestBody body, Action<ResponseCheckPlayData> callback)
    {
        string _params = "";
        if (requestParams != null)
        {
            foreach (var param in requestParams)
            {
                _params += $"{param.name}={param.value}";
            }
        }

        string jsonRaw = JsonUtility.ToJson(body);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRaw);

        UnityWebRequest unityWebRequest = new($"{hostApis}/{endPoint}", "POST")
        {
            uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw),
            downloadHandler = (DownloadHandler)new DownloadHandlerBuffer()
        };
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", $"Bearer {receiveFromWeb._authenticationData.GetToken()}");

        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            if (notifyNetwork != null)
                notifyNetwork.SetUp("Network Problem!", TypeNoti.NETWORK_ERROR);
        }
        else
        {
            var result = JsonUtility.FromJson<ResponseCheckPlayData>(unityWebRequest.downloadHandler.text);
            if (!result.success)
            {
                Debug.LogError(result.message);
                if (notifyNetwork != null)
                    notifyNetwork.SetUp(result.message, TypeNoti.ERROR);
            }
            else
            {
                callback?.Invoke(result);
            }
        }
    }
}
