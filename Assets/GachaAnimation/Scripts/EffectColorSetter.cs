using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EffectColorSetter : MonoBehaviour
{
    [SerializeField] private KagayakiTanpatu tanpatu;
    private DOTweenAnimation anim;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        anim = GetComponent<DOTweenAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor()
    {
        transform.localScale = Vector3.zero;
        image.color = tanpatu.GetNowColor();
        //anim.loops = (int)tanpatu.GetNowRarity();
        //anim.DOPlay();

        transform.DOScale(40, 0.4f).SetEase(Ease.InCubic).SetLoops((int)tanpatu.GetNowRarity());
    }
}
