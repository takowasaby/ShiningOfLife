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
            int rarity = Random.Range(0, 5);
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
