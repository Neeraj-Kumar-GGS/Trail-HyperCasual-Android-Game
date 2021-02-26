using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Purchasing;


public class CoinShop : MonoBehaviour
{
    public GameObject coinShopPanel;
    public AudioSource inAppPurchaseItem;
   
    public void BlackPanelBackground()
    {
        coinShopPanel.SetActive(false);
    }
    public void OnPurchaseCompleteCoin10000(Product product)
    {
        inAppPurchaseItem.Play();
        PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) + 10000);
    }
    public void OnPurchaseCompleteCoin4000(Product product)
    {
        inAppPurchaseItem.Play();
        PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) + 4000);
    }
    public void OnPurchaseCompleteCoin2000(Product product)
    {
        inAppPurchaseItem.Play();
        PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) + 2000);
    }
}
