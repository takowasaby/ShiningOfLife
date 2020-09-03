using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoPointReader : MonoBehaviour
{
    // Start is called before the first frame update

    public Text NLtext;
    public float zikan=0.0f;

    private Text Readertext;
    private int readerCnt = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zikan += Time.deltaTime;
        if(zikan >  0.5f)
        {
            readerCnt++;
            if (readerCnt > 6) readerCnt = 0;
            NLtext.text = "Now Loading";
            for(int i = 0; i < readerCnt; ++i)
            {
                NLtext.text += '.';
            }
            
            zikan = 0;
        }
    }
}
