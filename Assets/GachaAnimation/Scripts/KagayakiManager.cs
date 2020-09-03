using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class KagayakiManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirecter;
    [SerializeField] private GameObject kagayakiTati;
    [SerializeField] private List<KagayakiUnit> kagayakiUnits;
    [SerializeField] private List<Sprite> kagayakiKuntati;
    [SerializeField] private PremiumGachaRates gachaRates;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Start10Ren", Random.Range(0, 3));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetProbability()
    {
       foreach(KagayakiUnit k in kagayakiUnits)
        {
            float gachaRarity = Random.Range(0, 100f);
            int rarity = 0;

            if (gachaRarity <= gachaRates.lrRate)
            {
                rarity = 5;
            }else if (gachaRarity <= gachaRates.lrRate + gachaRates.urRate)
            {
                rarity = 4;
            }else if(gachaRarity <= gachaRates.lrRate + gachaRates.urRate + gachaRates.ssrRate)
            {
                rarity = 3;
            }else if(gachaRarity <= gachaRates.lrRate + gachaRates.urRate + gachaRates.ssrRate + gachaRates.srRate)
            {
                rarity = 2;
            }
            else if (gachaRarity <= gachaRates.lrRate + gachaRates.urRate + gachaRates.ssrRate + gachaRates.srRate+gachaRates.rRate)
            {
                rarity = 1;
            }
            else
            {
                rarity = 0;
            }


            k.SetRarity(rarity);
            k.ChangeRarity();
        }
    }

    public Sprite GetKagayakikun(int index)
    {
        if (index > kagayakiKuntati.Count) return null;

        return kagayakiKuntati[index];
    }

    public int GetKagayakiLength()
    {
        return kagayakiKuntati.Count;
    }

    public void Start10Ren()
    {
        kagayakiTati.SetActive(false);
        kagayakiTati.SetActive(true);
        playableDirecter.Play();
        SetProbability();
    }
}
