using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexts : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.1f * speed, 0.01f*speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 10f;
        }

    }
}
