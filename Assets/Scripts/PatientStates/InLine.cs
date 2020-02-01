using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLine : MonoBehaviour
{
    float lifeTime = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            // GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
            enabled = false;
        }
    }
}
