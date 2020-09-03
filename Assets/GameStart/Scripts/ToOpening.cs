using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToOpening : MonoBehaviour
{
    // Start is called before the first frame update
    private float zikanSwitch = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zikanSwitch += Time.deltaTime;
        if (Input.anyKeyDown && zikanSwitch > 3f)
        {
            SceneManager.LoadScene("Opening");
            
        }
    }
}
