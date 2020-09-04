using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTitle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public float zikan;
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        zikan += Time.deltaTime;
        if(zikan > 5f)
        {
            button.SetActive(true);

        }
    }
}
