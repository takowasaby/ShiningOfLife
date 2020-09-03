using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim.Play("chara");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
