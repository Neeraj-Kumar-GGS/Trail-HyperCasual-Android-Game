using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    float timeCountDownDestroy = 8f;
    void Update()
    {
        timeCountDownDestroy -= Time.deltaTime;
        
        if (timeCountDownDestroy < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
