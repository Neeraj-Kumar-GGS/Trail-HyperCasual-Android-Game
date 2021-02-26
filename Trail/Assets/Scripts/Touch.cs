using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    public TrailCollider trailCollider;
    public Text coinScoreText;
    public GameObject[] holdText;
    public GameObject[] trails;
    bool pressed = false;
    int isSpawnning = 0;
    private void Start()
    {
       Time.timeScale = 1f;
        isSpawnning = 0;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("IsSpawnning", isSpawnning);

        if (pressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            for (int i = 0; i < trails.Length; i++)
            { 
                trails[i].transform.position = new Vector3(ray.origin.x, ray.origin.y, 1000);
            }
            coinScoreText.transform.position = new Vector3(ray.origin.x, ray.origin.y + 40f, 1000);
        }
      
     

    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isSpawnning = 1;
        Time.timeScale = 1f;
        pressed = true;
        for (int i = 0; i < trails.Length; i++)
        {
            if(i == PlayerPrefs.GetInt("TrailIndex", 0))
            { 
                trails[i].SetActive(true);
        
            }
            else trails[i].SetActive(false);



        }

        for (int i = 0; i < holdText.Length; i++)
        holdText[i].SetActive(false);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        pressed = false;
        for (int i = 0; i < trails.Length; i++)
        {
               trails[i].SetActive(false);

        }


        trailCollider.Die();
    }
  
}
