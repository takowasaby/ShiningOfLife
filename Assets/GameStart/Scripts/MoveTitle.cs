using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <900f)
        {
            transform.Translate(2f, 0f, 0f);
        }
    }
}
