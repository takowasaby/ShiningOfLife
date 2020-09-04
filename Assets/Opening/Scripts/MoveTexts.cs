using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveTexts : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    private float moveDis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDis = 0.1f * speed;
        transform.Translate(0, moveDis,0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 10000f*Time.deltaTime;
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 1000f*Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {

        moveDis = 0.1f * speed;
        transform.Translate(0, moveDis, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 10000f * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 1000f * Time.deltaTime;
        }
    }
}
