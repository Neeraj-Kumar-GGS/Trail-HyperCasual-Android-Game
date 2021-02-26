using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
 {
    public GameObject adpoints250;
    public void AdButtonRewaeded()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            adpoints250.SetActive(true);
            Advertisement.Show("rewardedVideo");
            PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) + 250);
        }
        else
            adpoints250.SetActive(false);

    }
    private void Update()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            adpoints250.SetActive(true);
           
        }
        else
            adpoints250.SetActive(false);
    }
}
