
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using JetBrains.Annotations;

// UnityWebRequest WebScraper Fetching CryptoCurrency Data using CryptoCompare API

public class WebScraper_v4 : MonoBehaviour
{
    public DataHandle Handler;

    public string curType = "";
    public float BTCPrice = 0;
    public float ETHPrice = 0;
    public float SOLPrice = 0;
    public int couroutinesCompleted = 0;

    public bool buttonPressed = false; 
    void Start()
    {
        //BTC Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 1));

        //ETH Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 2));

        //SOL Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=SOL&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 3));
    }

    public void OnButtonClick()
    {
   
        //BTC Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 1));

        //ETH Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 2));

        //SOL Coroutine
        StartCoroutine(GetRequest("https://min-api.cryptocompare.com/data/price?fsym=SOL&tsyms=GBP&api_key=1f8e92d6a4d92182822868166975029c6bef43d1f2d973698c058355d6165a9a", 3));
        
        buttonPressed = true;

    }

    IEnumerator GetRequest(string url, int type)
    {


        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            if (type == 1)
                curType = "BTC";
            else if (type == 2)
                curType = "ETH";
            else if (type == 3)
                curType = "SOL";
            else
                Debug.Log("Incorrect curType used");
            yield return webRequest.SendWebRequest(); //Sends web request to url in GetRequest parameters

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            string source = webRequest.downloadHandler.text;

            source = source.Remove(0, 7);
            source = source.TrimEnd('}');
            //Debug.Log("Data grabbed:\n" + source); //Displays data in debug console

            //int count = 0;

            switch (webRequest.result) //Creates switch case for the result of the request
            {
                //Test for Request Errors
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    couroutinesCompleted++;
                    if (type == 1)
                    {
                        Debug.Log("BTC Price:\nReceived: " + source);
                        BTCPrice = float.Parse(source);

                    }
                    else if (type == 2)
                    {
                        Debug.Log("ETH Price:\nReceived: " + source);
                        ETHPrice = float.Parse(source);
                    }
                    else if (type == 3)
                    {
                        Debug.Log("SOL Price:\nReceived: " + source);
                        SOLPrice = float.Parse(source);
                    }
                    else
                        Debug.Log("Incorrect curType used");
                    //Debug.Log(curType+" Price:\nReceived: " + source);
                    break;
            }
            if (couroutinesCompleted == 3){ //When All 3 Coroutines are completed and the button hasnt been pressed
                Handler.setCoinPosition(); //Calls when final coin result is grabbed.
            }
        }
    }
}

