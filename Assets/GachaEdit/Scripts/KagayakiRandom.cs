using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KagayakiRandom : MonoBehaviour
{
    private Image image;
    [SerializeField] private List<Sprite> kagayakitati;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = kagayakitati[Random.Range(0, kagayakitati.Count)];

        image = GetComponent<Image>();
        image.sprite = sprite;
    }

    
}
