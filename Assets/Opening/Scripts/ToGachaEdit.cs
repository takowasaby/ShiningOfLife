using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGachaEdit : MonoBehaviour
{
    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.position.y > 1900)
        {
            SceneManager.LoadScene("GachaEdit");
        }
    }
}
