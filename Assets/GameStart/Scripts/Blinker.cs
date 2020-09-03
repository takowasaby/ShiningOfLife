//https://vend9520-lab.net/?p=382

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;

    private float time = 0.0f;
    private float zikanSwitch = 0.0f;
    private Text text;
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        text.color= new Color(66/255,70/255,91/255,0);
    }

    // Update is called once per frame
    void Update()
    {
        zikanSwitch += Time.deltaTime;
        if (zikanSwitch > 2f)
        {
            text.color = GetAlphaColor(text.color);
        }
        
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 0.35f * speed;
        color = new Color(66/255,70/255,91/255,Mathf.Sin(time));
        return color;
    }
}
