using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLoader : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] bricks;
    public GameObject coin;

    float timeGapInSpawnningMap;
    float distanceBetweenCoinGap = 0f;
    public float distanceAfterCoinGapArrives;
    float remainingTime;

    int randomnNum = 3;

    float upwardSpeed;
    
    float distanceCovered;
    int countOfCoinGap = 1;


    private void Start()
    {
        remainingTime = 0f;
        
    }
    private void Update()
    {

        upwardSpeed = PlayerPrefs.GetFloat("UpwardSpeed");
           timeGapInSpawnningMap = 20f * Time.deltaTime/ upwardSpeed;

        remainingTime -= Time.deltaTime;
        distanceBetweenCoinGap = PlayerPrefs.GetFloat("Distance", 0f);


        if (remainingTime < 0f && distanceBetweenCoinGap < distanceAfterCoinGapArrives * countOfCoinGap && PlayerPrefs.GetInt("IsSpawnning") == 1)
        {
            randomnNum = Random.Range(randomnNum - 1, (randomnNum + 1) + 1);
            if (randomnNum < 1)
                randomnNum = 1;
            if (randomnNum > 7)
                randomnNum = 7;

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != randomnNum && i != randomnNum - 1 && i != randomnNum + 1)
                {
                    Instantiate(bricks[PlayerPrefs.GetInt("BlockIndex", 0)], spawnPoints[i].transform.position, Quaternion.identity);
                }
                else
                {
                    if (Random.Range(1, 18) == 1)
                        Instantiate(coin, spawnPoints[i].transform.position, Quaternion.identity);
                
                }

            }
            remainingTime = timeGapInSpawnningMap;
        }



        if (distanceBetweenCoinGap > distanceAfterCoinGapArrives * countOfCoinGap && remainingTime < 0f && PlayerPrefs.GetInt("IsSpawnning") == 1)
        {
            for (int i = 0; i < spawnPoints.Length; i++) 
            {
                if (Random.Range(1, 4) == 1)
                    Instantiate(coin, spawnPoints[i].transform.position, Quaternion.identity);
            }
            remainingTime = timeGapInSpawnningMap;

            if (distanceBetweenCoinGap > distanceAfterCoinGapArrives * countOfCoinGap  + 50f)
            {
                distanceBetweenCoinGap = PlayerPrefs.GetFloat("Distance", 0f);
                countOfCoinGap++;
            }
        }

     
    }
}
