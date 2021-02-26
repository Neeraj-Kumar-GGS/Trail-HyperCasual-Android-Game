using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TrailCollider : MonoBehaviour
{
    int coinScore = 0;
    public Text coinScoreText;
    public GameObject coinScoreUIgameObject;

    public AudioSource coinCollect;
    public AudioSource die;
    bool isDied;
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Die();
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(225, 0, 0 );
        }


        if (collision.gameObject.tag.Equals("Coin"))
        {
            coinCollect.Play();
            Destroy(collision.gameObject);
            coinScore++;

            coinScoreUIgameObject.SetActive(true);

           // Invoke("DisableCoinScoreText", 1.5f);

            if (SceneManager.GetActiveScene().buildIndex == 1)
                PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore") + 1);

            PlayerPrefs.SetInt("Experience", PlayerPrefs.GetInt("Experience", 0) + 1);


            if (SceneManager.GetActiveScene().buildIndex == 1)
                if (PlayerPrefs.GetInt("HighScoreCoin", 0) < coinScore)
                PlayerPrefs.SetInt("HighScoreCoin", coinScore);
        }

    }

    void DisableCoinScoreText()
    {
        coinScoreUIgameObject.SetActive(false);
    }

    private void Update()
    {
   

        coinScoreText.text = coinScore.ToString();

    }
    public void Die()
    {
        
        Invoke("LoadMainMenu", 1.5f);
        this.gameObject.SetActive(false);
        Handheld.Vibrate();
        if (isDied == false)
        {
            die.Play();
            isDied = true;
        }
    }
    public void LoadMainMenu()
    {
    
        SceneManager.LoadScene("MainMenu");
    }





}

