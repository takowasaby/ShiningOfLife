//https://otologic.jp/free/se/onmtp-others01.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{
    // Start is called before the first frame update
    public float zikan = 0f;
    public float size = 0.1f;
    public bool koukaonFlag = false;

    public AudioSource audio;
    public AudioClip pon;
    void Start()
    {
        GetComponent<Image>().color= new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size,size,size);
        zikan += Time.deltaTime;
        if(zikan >= 4f)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            if (size < 1.0f)
            {
                size += 0.01f;
                transform.Rotate(0f, 0f, size*0.5f);
                if (koukaonFlag == false)
                {
                    audio.PlayOneShot(pon);
                    koukaonFlag = true;
                }
            }
        }
    }
}
