using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultSet : MonoBehaviour
{
    [SerializeField] private GameObject resultObject;
    [SerializeField] private KagayakiManager kagayakiManager;
    [SerializeField] private List<ResultUnit> resultUnits=new List<ResultUnit>();
    [SerializeField] private KagayakiTanpatu kagayaki;

    private int nowSet = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResultOpen();
        }
    }

    public void ResultOpen()
    {
        resultObject.SetActive(true);
        var tgt = 100f;
        var time = 1f;
        var piyo=0f;


        Sequence sequence = DOTween.Sequence()
            .Append(DOTween.To(() => piyo, (x) => piyo = x, tgt, time))
            .AppendCallback(() => { 
                Debug.Log("completed");

                CountSet();
            })
            .SetLoops(10, LoopType.Restart)
            .OnComplete(() =>
            {
                Invoke("End10Ren", 3f);

                Debug.Log("10completed");
            })
            .Play();
    }

    private void CountSet()
    {
        Debug.Log(nowSet);
       
        var kagayakiSprite = kagayaki.GetKagayaki();
        var rarityString = kagayaki.GetRaritySet();
        var colorSet = kagayaki.GetColorSet();

        Debug.Log(kagayakiSprite[nowSet]);

        resultUnits[nowSet].gameObject.SetActive(true);
        resultUnits[nowSet].SetCharaProfile(kagayakiSprite[nowSet], rarityString[nowSet], colorSet[nowSet]);


        nowSet++;
    }

    private void End10Ren()
    {
        var defaultScale = resultObject.transform.localScale;
        resultObject.transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
        {
            //resultObject.transform.localScale = defaultScale;
            resultObject.SetActive(false);
            nowSet = 0;
            kagayaki.Init10Ren();
            Invoke("Uaa", Random.Range(0, 5f));
        });

    }

    private void Uaa()
    {
        kagayakiManager.Start10Ren();
    }
}
