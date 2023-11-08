using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataHandle : MonoBehaviour
{
    public WebScraper_v4 scraper;
    public CameraHandle CameraHandle;
    public GameObject BTC;
    public GameObject ETH;
    public GameObject SOL;

    public GameObject BTCPriceText;
    public GameObject ETHPriceText;
    public GameObject SOLPriceText;

    public float scale = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        BTC.transform.position = SOL.transform.position;
        ETH.transform.position = SOL.transform.position;

        BTCPriceText.GetComponent<TextMeshProUGUI>().text = "BTC(GBP): £";
        ETHPriceText.GetComponent<TextMeshProUGUI>().text = "ETH(GBP): £";
        SOLPriceText.GetComponent<TextMeshProUGUI>().text = "SOL(GBP): £";

    }

    public void setCoinPosition()
    {       

        SOL.transform.localScale *= scraper.SOLPrice;
        ETH.transform.localScale *= scraper.ETHPrice;
        BTC.transform.localScale *= scraper.BTCPrice;
        

        ETH.transform.position += new Vector3(ETH.transform.localScale.x/2,0,0);
        ETH.transform.position += new Vector3(SOL.transform.localScale.x*2,0,0);

        //BTC.transform.position = ETH.transform.position;
        BTC.transform.position += new Vector3(BTC.transform.localScale.x / 2, 0, 0);
        BTC.transform.position += new Vector3(ETH.transform.localScale.x*2 , 0, 0);

        CameraHandle.setValues();
    }

    void Update()
    {
        BTCPriceText.GetComponent<TextMeshProUGUI>().text = "BTC(GBP): £" + scraper.BTCPrice.ToString();
        ETHPriceText.GetComponent<TextMeshProUGUI>().text = "ETH(GBP): £" + scraper.ETHPrice.ToString();
        SOLPriceText.GetComponent<TextMeshProUGUI>().text = "SOL(GBP): £" + scraper.SOLPrice.ToString();
    }
}
