using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KagayakiRandom : MonoBehaviour
{
    private Image image;
    [SerializeField] private List<Sprite> kagayakitati;

    public bool isRandomSaisei = false;
    public float time = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        Sprite sprite = kagayakitati[Random.Range(0, kagayakitati.Count)];

        image = GetComponent<Image>();
        image.sprite = sprite;

        if (isRandomSaisei)
        {
            TweenSet();
        }
    }

    public void TweenSet()
    {
        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, time).SetEase(Ease.OutCubic))
            .AppendCallback(() => { ChangeKagayaki(); })
            .Append(transform.DOScale(Vector3.one, time).SetEase(Ease.OutCubic))
            .SetLoops(-1);
        sequence.Play();
    }

    public void ChangeKagayaki()
    {
        Sprite sprite = kagayakitati[Random.Range(0, kagayakitati.Count)];
        image.sprite = sprite;
    }
}
