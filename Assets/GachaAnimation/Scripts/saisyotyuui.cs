using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saisyotyuui : MonoBehaviour
{
    [SerializeField] private MessageScrollBehavior behaviour;

    // Start is called before the first frame update
    void Start()
    {
        behaviour.RequestScroll("プレミアムガチャの様子をモニタリングしています");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
