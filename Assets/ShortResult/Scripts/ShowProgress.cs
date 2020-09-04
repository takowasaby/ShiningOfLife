﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    public Text totalSales, finalSatisfaction, finalNumberOfUsers, rank;
    long totalSalesN,  finalNumberOfUsersN;
    float finalSatisfactionN;
    String[] rankArray = {"覇権","特になし","大コケ","オワコン" };

    void Start()
    {
        // 総売上はmoneysの総和
        totalSalesN = mp.moneys.Last();
        totalSales.text += totalSalesN.ToString() + "円";
        // 最終好感度は最後の月の好感度
        finalSatisfactionN = sp.satisFactions.Last();
        finalSatisfaction.text += finalSatisfactionN.ToString();
        // 総ユーザー数は各セグメントの最後の月の和
        finalNumberOfUsersN = ucp.MukakinUserCounts.Last() + ucp.BikakinUserCounts.Last() + ucp.TyukakinUserCounts.Last() + ucp.JukakinUserCounts.Last() + ucp.SekiyuoCounts.Last();
        finalNumberOfUsers.text += finalNumberOfUsersN.ToString()+"人";
        // rankは要相談

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(co.Ceiling);
    }



}
