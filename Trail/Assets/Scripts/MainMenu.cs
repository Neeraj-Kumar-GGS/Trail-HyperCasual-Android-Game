using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text totalCoinScore;
    public Text distance;
    public Text maxDistance;
    public Text tier;
    public AudioSource buttonTick;
    public AudioSource buttonPop;
    public Animator endWipe;

    void Update()
    {
        
        if (PlayerPrefs.GetInt("Experience") < 30000)
        {
            tier.text = "Gold I";
            tier.color = new Color(255, 167, 255);
            if (PlayerPrefs.GetInt("Experience") < 7000)
            {
                tier.text = "Gold II";
                tier.color = new Color(255, 167, 255);
                if (PlayerPrefs.GetInt("Experience") < 5800)
                {
                    tier.text = "Gold III";
                    tier.color = new Color(255, 167, 255);
                    if (PlayerPrefs.GetInt("Experience") < 4600)
                    {
                        tier.text = "Gold IV";
                        tier.color = new Color(255, 167, 255);
                        if (PlayerPrefs.GetInt("Experience") < 3400)
                        {
                            tier.text = "Gold V";
                            tier.color = new Color(255, 167, 255);
                            if (PlayerPrefs.GetInt("Experience") < 2600)
                            {
                                tier.text = "Silver I";
                                tier.color = new Color(215, 215, 215);
                                if (PlayerPrefs.GetInt("Experience") < 1800)
                                {
                                    tier.text = "Silver II";
                                    tier.color = new Color(215, 215, 215);
                                    if (PlayerPrefs.GetInt("Experience") < 1200)
                                    {
                                        tier.text = "Silver III";
                                        tier.color = new Color(215, 215, 215);
                                        if (PlayerPrefs.GetInt("Experience") < 900)
                                        {
                                            tier.text = "Silver IV";
                                            tier.color = new Color(215, 215, 215);
                                            if (PlayerPrefs.GetInt("Experience") < 700)
                                            {
                                                tier.text = "Silver V";
                                                tier.color = new Color(215, 215, 215);
                                                if (PlayerPrefs.GetInt("Experience") < 500)
                                                {
                                                    tier.text = "Bronze I";
                                                    tier.color = new Color(225, 0, 35);
                                                    if (PlayerPrefs.GetInt("Experience") < 360)
                                                    {
                                                        tier.text = "Bronze II";
                                                        tier.color = new Color(225, 0, 35);
                                                        if (PlayerPrefs.GetInt("Experience") < 220)
                                                        {
                                                            tier.text = "Bronze III";
                                                            tier.color = new Color(225, 0, 35);
                                                            if (PlayerPrefs.GetInt("Experience") < 100)
                                                            {
                                                                tier.text = "Bronze IV";
                                                                tier.color = new Color(225, 0, 35);
                                                                if (PlayerPrefs.GetInt("Experience") < 50)
                                                                {
                                                                    tier.text = "Bronze V";
                                                                    tier.color = new Color(225, 0, 35);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        totalCoinScore.text = PlayerPrefs.GetInt("CoinScore", 0).ToString();

        distance.text = (PlayerPrefs.GetFloat("Distance", 0f)).ToString("0");

        maxDistance.text = (PlayerPrefs.GetFloat("MaxDistance", 0f)).ToString("0");
    }

    public void PlayButton()
    {
        Invoke("PlayButtonDelay", 0.8f);
        endWipe.SetTrigger("Play");
        buttonTick.Play();
    }
    void PlayButtonDelay()
    {
        SceneManager.LoadScene("Level");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void UnlockButton()
    {
        SceneManager.LoadScene("Unlocks");
        buttonTick.Play();

    }
    public void PracticeMode()
    {
        endWipe.SetTrigger("Play");
        buttonTick.Play();
        Invoke("PracticeModeDelay", 0.8f);

    }
    void PracticeModeDelay()
    {
        SceneManager.LoadScene("PracticeMode");
    }


}
