using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KagayakiTanpatu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject tanpatuObject;
    [SerializeField] private GameObject RarityObject;
    [SerializeField] private Text rarityText1;
    [SerializeField] private Text rarityText2;
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterImage;
    [SerializeField] private Animator[] sourceAnimators;
    [SerializeField] private KagayakiManager kManager;

    private int gachaNum = 0;//0-9
    private float nowRarity = 0;
    private string nowRarityRankText;
    private Sprite nowKagayaki;
    // Start is called before the first frame update
    void Start()
    {
        gachaNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextGacha();
        }   
    }

    public void NextGacha()
    {
        nowRarity = Random.Range(0,5.5f);
        nowKagayaki = kManager.GetKagayakikun(Random.Range(0, 4));
        Tanpatu(nowRarity, nowKagayaki);

        gachaNum++;
    }


    public void Tanpatu(float rarity,Sprite kagayaki)
    {
        tanpatuObject.SetActive(true);
        SetRarity(rarity);

        int rarityInt = (int)rarity;

        switch (rarityInt)
        {
            case 0:
                nowRarityRankText = "Normal";
                break;

            case 1:
                nowRarityRankText = "Rare";
                break;

            case 2:
                nowRarityRankText = "Super Rare";
                break;

            case 3:
                nowRarityRankText = "S Super Rare";
                break;

            case 4:
                nowRarityRankText = "Ultra Rare";
                break;

            case 5:
                nowRarityRankText = "Legend Rare";
                break;
        }


    }

    public void CloseTanpatu()
    {
        tanpatuObject.SetActive(false);
    }

    public void RarityEffectOpen()
    {      
        RarityObject.SetActive(true);
        rarityText1.text = nowRarityRankText;
        rarityText2.text = nowRarityRankText;
        characterName.text = nowKagayaki.name;
        characterImage.sprite = nowKagayaki;
    }

    public void RarityEffectClose()
    {
        CloseTanpatu();
        RarityObject.SetActive(false);
    }

    public void SetRarity(float rarity)
    {
        animator.SetFloat("aaa", rarity);
        animator.SetTrigger("ChangeRarity");
    }
}
