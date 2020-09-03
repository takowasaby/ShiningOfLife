using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >500f)
        {
            transform.Translate(-2f, 0f, 0f);
        }
    }
}
