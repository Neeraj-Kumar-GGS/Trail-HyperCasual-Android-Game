using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveEveryThingUpwards : MonoBehaviour
{
    public GameObject[] everything;
    public GameObject setDifficultyPanel;
    [Range(50, 400)]
    public float upwardSpeed;
    public Transform[] trails;
    public Text distanceCoveredScore;
    float distanceCovered;
    public Slider difficultySlider;
    public Gradient sliderGradient;
    public Image fill;
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("Experience") < 1500)
        {
            upwardSpeed = 120f;
            if (PlayerPrefs.GetInt("Experience") < 1000)
            {
                upwardSpeed = 90f;
                if (PlayerPrefs.GetInt("Experience") < 500)
                {
                    upwardSpeed = 70f;
                    if (PlayerPrefs.GetInt("Experience") < 100)
                    { 
                        upwardSpeed = 50f;
                    }
                }
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
            difficultySlider.value = PlayerPrefs.GetFloat("DifficultySlider", 0);
    }
    void Update()
    {   if(PlayerPrefs.GetInt("IsSpawnning") == 1)
        setDifficultyPanel.transform.Translate(0, upwardSpeed * Time.deltaTime * 3, 0);
        //incresing upward speed gradually in level scene
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            upwardSpeed = (upwardSpeed + 0.02f);
        }
        PlayerPrefs.SetFloat("UpwardSpeed", upwardSpeed * Time.deltaTime);
        for (int i = 0; i < everything.Length; i++)
        {
            everything[i].transform.Translate(0, upwardSpeed * Time.deltaTime , 0);
        }

        for (int i = 0; i < trails.Length; i++)
        { 
        
            if (trails[i].gameObject.active == true)
            { 
                
                distanceCovered = (trails[i].position.y / 10f) + 1;
                if (distanceCovered < 0)
                    distanceCovered = 0;
            }
        }




        if (distanceCovered > PlayerPrefs.GetFloat("MaxDistance", 0f))
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            PlayerPrefs.SetFloat("MaxDistance", distanceCovered);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
            PlayerPrefs.SetFloat("Distance", distanceCovered);

        distanceCoveredScore.text = distanceCovered.ToString("0");


        if (SceneManager.GetActiveScene().buildIndex == 2)
        { 
            upwardSpeed = difficultySlider.value;
            fill.color = sliderGradient.Evaluate(difficultySlider.normalizedValue);
            PlayerPrefs.SetFloat("DifficultySlider", difficultySlider.value);

        }

        
        
    }


    
    
}
