using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class KagayakiManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirecter;
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

    public Sprite GetKagayakikun(int index)
    {
        if (index > kagayakiKuntati.Count) return null;

        return kagayakiKuntati[index];
    }

    public void Start10Ren()
    {
        playableDirecter.Play();
    }
}
