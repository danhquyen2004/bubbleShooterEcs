using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveFromWeb : MonoBehaviour
{
    public AuthenticationData _authenticationData;

    //private void Awake()
    //{
    //    _authenticationData = new(
    //        "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiIyNTU2MjAwMDAwMjEiLCJpYXQiOjE3MTg4NzU0MDAsImV4cCI6MTcxOTQ4MDIwMH0.R_JWGmiCkEIBVzhyZh7546N32CIa0TCjip_KouXo9X4I7UwD4cNn0UvrAOUODW0pEex312fRGrCAbJjOscaL5w",
    //        "255620000021",
    //        "GUNWAR",
    //        "",
    //        ""
    //        );
    //}
    public void ReceiveMessage(string _message)
    {
        Uri url = new(_message);
        _authenticationData = new(
            HttpUtility.ParseQueryString(url.Query).Get("token"),
            HttpUtility.ParseQueryString(url.Query).Get("msisdn"),
            HttpUtility.ParseQueryString(url.Query).Get("game_code"),
            HttpUtility.ParseQueryString(url.Query).Get("host"),
            HttpUtility.ParseQueryString(url.Query).Get("link_shop"),
            HttpUtility.ParseQueryString(url.Query).Get("isDemo")
            );
    }
}

public class AuthenticationData
{
    private string token;
    private string msisdn;
    private string gameCode;
    private string host;
    private string linkShop;
    private bool isDemo;

    public AuthenticationData(string token, string msisdn, string gameCode, string host, string linkShop, string isDemo)
    {
        this.token = token;
        this.msisdn = msisdn;
        this.gameCode = gameCode;
        this.host = host;
        this.linkShop = linkShop;
        this.isDemo = isDemo == "true";
    }

    public string GetToken() { return this.token; }
    public string GetMsisdn() { return this.msisdn; }
    public string GetGameCode() { return this.gameCode; }
    public string GetHost() { return this.host; }
    public string GetLinkShop() { return this.linkShop; }
    public bool GetIsDemo() { return this.isDemo; }
}
