using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToShortResult : MonoBehaviour
{
    // Start is called before the first frame update
    public float zikan = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zikan += Time.deltaTime;
        if(zikan > 5f)
        {
            SceneManager.LoadScene("ShortResult");
        }
    }
}
