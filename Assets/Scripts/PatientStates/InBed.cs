using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBed : MonoBehaviour
{
    float lifeTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
            enabled = false;
        }
    }
}
