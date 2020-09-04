using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTexture : MonoBehaviour
{
    [SerializeField] private List<RenderTexture> screenRenders;
    [SerializeField] private Transform screenParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in screenParent)
        {
            RawImage raw = child.GetComponent<RawImage>();

            raw.texture = screenRenders[Random.Range(0, screenRenders.Count)];
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
