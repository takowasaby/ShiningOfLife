using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class KagayakiTanpatu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject tanpatuObject;
    [SerializeField] private GameObject RarityObject;
    [SerializeField] private Text rarityText1;
    [SerializeField] private Text rarityText2;
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterImage;
    [SerializeField] private List<Animator> sourceAnimators;
    [SerializeField] private KagayakiManager kManager;
    [SerializeField] private ResultSet resultSet;
    private MessageScrollBehavior behaviour;

    private int gachaNum = 0;//0-9
    private float nowRarity = 0;
    private string nowRarityRankText;
    private Color nowRarityColor;
    private Sprite nowKagayaki;

    private List<Sprite> kagayakiSprite;
    private List<string> raritySet;
    private List<Color> colorSet;
    // Start is called before the first frame update
    void Start()
    {
        gachaNum = 0;
        kagayakiSprite = new List<Sprite>();
        raritySet = new List<string>();
        colorSet = new List<Color>();

        behaviour = GameObject.FindGameObjectWithTag("Respawn").GetComponent<MessageScrollBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void NextGacha()
    {
        //Debug you
        //nowRarity = Random.Range(0,5.5f);
        nowKagayaki = kManager.GetKagayakikun(UnityEngine.Random.Range(0, kManager.GetKagayakiLength()));
        //

        if (gachaNum < 10)
        {
            nowRarity = sourceAnimators[gachaNum].GetFloat("aaa");

            Tanpatu(nowRarity, nowKagayaki);

            

            gachaNum++;
        }
        else
        {
            //Resultの表示
            resultSet.ResultOpen();

            
        }
        
    }

    public void Init10Ren()
    {
        //色々初期化
        gachaNum = 0;
        kagayakiSprite = new List<Sprite>();
        raritySet = new List<string>();
        colorSet = new List<Color>();
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
                nowRarityColor = Color.black;
                break;

            case 1:
                nowRarityRankText = "Rare";
                nowRarityColor = Color.red;
                break;

            case 2:
                nowRarityRankText = "Super Rare";
                nowRarityColor = new Color(0, 1, 0);
                break;

            case 3:
                nowRarityRankText = "S Super Rare";
                nowRarityColor = new Color(0, 1, 1);
                break;

            case 4:
                nowRarityRankText = "Ultra Rare";
                nowRarityColor = Color.yellow;
                break;

            case 5:
                nowRarityRankText = "Legend Rare";
                nowRarityColor = new Color(1,0,1);//murasaki
                break;
        }

        if (rarityInt >= 4)
        {
            var intValue = UnityEngine.Random.Range(0, Enum.GetValues(typeof(HandleNames)).Length);
            HandleNames names = (HandleNames)Enum.ToObject(typeof(HandleNames), intValue);
            string name = names.ToString();

            string message = name + "さんが "+nowRarityRankText+" " + nowKagayaki.name + " を引き当てました";
            behaviour.RequestScroll(message);
        }

        raritySet.Add(nowRarityRankText);
        kagayakiSprite.Add(nowKagayaki);
        colorSet.Add(nowRarityColor);
    }

    public Color GetNowColor()
    {
        return nowRarityColor;
    }

    public float GetNowRarity()
    {
        return nowRarity;
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
        rarityText1.color = nowRarityColor;
        rarityText2.color = nowRarityColor;
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


    public List<string> GetRaritySet()
    {
        return raritySet;
    }

    public List<Color> GetColorSet()
    {
        return colorSet;
    }

    public List<Sprite> GetKagayaki()
    {
        return kagayakiSprite;
    }

    private enum HandleNames
    {
        漆黒の墜天使,
        kirito,
        kuraudo,
        ああああ,
        頭ハッピーセット,
        asuna,
        暗黒騎士たかし,
        聖天使猫姫,
        ゆうた,
        気持ち悪い,
        J,
        けんた,
        目玉男,
    }

}
