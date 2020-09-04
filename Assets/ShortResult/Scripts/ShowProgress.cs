using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class ShowProgress : MonoBehaviour
{
    // Rankをきめようね

    // CommandOpenness 
    // member(bool) : CompleteGacha, HukubukuroGacha, ConfirmGacha, Update, StoneDistribution, Ceiling;
    public CommandOpenness co;
    // MoneyProgress
    // member : moneys(List<long>)
    public MoneyProgress mp;
    // TermProgress
    // member : currentTerm(int), termNames(string[])
    public TermProgress tp;
    // SatisfactionProgress
    // member : satisFactions(List<float>)
    public SatisfactionProgress sp;
    // UserCountProgress ucp
    // member(List<long>) : MukakinUserCounts,BikakinUserCounts,TyukakinUserCounts,JukakinUserCounts,SekiyuoCounts
    public UserCountProgress ucp;

    // display
    public Text totalSales, finalSatisfaction, finalNumberOfUsers;
    long totalSalesN,  finalNumberOfUsersN;
    float finalSatisfactionN;
    String[] rankArray = {"覇権","特になし","大コケ","オワコン" };
    public int rankNum = 0;

    // animation用
    public long tsN = 0;
    public float fsf = 0f;
    public long fnou = 0;
    public int tweenNum = 0;
    public float zikan = 0.0f;

    public Image stamp;

    public AudioSource audio;
    public AudioClip money;

    void Start()
    {
        // 総売上はmoneysの総和
        totalSalesN = mp.moneys.Last();
       // totalSalesN = 50000000000;
        TweenSales(totalSalesN);
        //audio.PlayOneShot(money);

        // 最終好感度は最後の月の好感度
        finalSatisfactionN = sp.satisFactions.Last();
        
        //finalSatisfaction.text = finalSatisfactionN.ToString();
        // 総ユーザー数は各セグメントの最後の月の和
        finalNumberOfUsersN = ucp.MukakinUserCounts.Last() + ucp.BikakinUserCounts.Last() + ucp.TyukakinUserCounts.Last() + ucp.JukakinUserCounts.Last() + ucp.SekiyuoCounts.Last();
        //finalNumberOfUsers.text = finalNumberOfUsersN.ToString();
        //finalNumberOfUsersN = 10000000000;
        // rank
        if (totalSalesN > 100000000000)
        {
            //覇権
            rankNum = 1;
            stamp.sprite = Resources.Load<Sprite>("stamp_haken");
        }else if(totalSalesN > 50000000000)
        {
            //特になし
            rankNum = 2;
            stamp.sprite = Resources.Load<Sprite>("stamp_tokuninashi");
        }
        else if(totalSalesN > 10000000000)
        {
            //オワコン
            rankNum = 3;
            stamp.sprite = Resources.Load<Sprite>("stamp_owakon");
        }
        else
        {
            //大コケ
            rankNum = 4;
            stamp.sprite = Resources.Load<Sprite>("stamp_ookoke");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(co.Ceiling);
        zikan += Time.deltaTime;
        if (zikan > 0.8f && tweenNum==0)
        {
            TweenFloat(finalSatisfactionN);
            tweenNum = 1;
            audio.PlayOneShot(money);
        }else if(zikan > 1.8f && tweenNum == 1)
        {
            TweenNumUser(finalNumberOfUsersN);
            tweenNum = 2;
            audio.PlayOneShot(money);
        }
        else if (zikan > 2.8f && tweenNum == 2)
        {
            tweenNum = 3;
            audio.PlayOneShot(money);
        }
            totalSales.text = tsN.ToString();
        finalSatisfaction.text = fsf.ToString();
        finalNumberOfUsers.text = fnou.ToString();

        
    }

    void TweenSales(long tgt)
    {
        var time = 1f;
        
        DOTween.To(() => tsN, (x) => tsN = x, tgt, time).SetEase(Ease.InOutSine);
    }
    void TweenFloat(float tgt)
    {
        var time = 1f;

        DOTween.To(() => fsf, (x) => fsf = x, tgt, time).SetEase(Ease.InOutSine);
    }

    void TweenNumUser(long tgt)
    {
        var time = 1f;

        DOTween.To(() => fnou, (x) => fnou = x, tgt, time).SetEase(Ease.InOutSine);
    }


}
