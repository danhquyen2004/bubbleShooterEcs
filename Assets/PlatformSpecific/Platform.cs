using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Platform
{
    private static IPlatformService _platformService;

    public static void Initialize()
    {
        Debug.Log(Application.platform);

        if (Application.platform == RuntimePlatform.Android)
            _platformService = new AndroidPlatformService();
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            _platformService = new IosPlatformService();
        else if (Application.platform == RuntimePlatform.WebGLPlayer)
            _platformService = new WebGLPlatformService();
        else
            _platformService = new DefaultPlatformService();
    }

    public static IPlatformService PlatformService => _platformService;
}
