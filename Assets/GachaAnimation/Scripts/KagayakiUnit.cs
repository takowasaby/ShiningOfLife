﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagayakiUnit : MonoBehaviour
{
    [SerializeField] private int rarity = 1;//0-5でそれぞれのレアリティ設定
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        SetRarity(Random.Range(0, 5));
        ChangeRarity();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeRarity();
        }
    }

    public void SetRarity(int rarity)
    {
        this.rarity = rarity;
        //animator.SetInteger("rarity", rarity);
        animator.SetFloat("aaa", rarity+0.5f);
    }

    public void ChangeRarity()
    {
        animator.SetTrigger("ChangeRarity");
    }
}
