using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/MoneyProgress")]
public class MoneyProgress : ScriptableObject
{
    public List<long> moneys = new List<long>();

    public void SaveProgress(long money, int term)
    {
        for (var i = this.moneys.Count; i < term + 1; i++)
        {
            this.moneys.Add(0L);
        }

        this.moneys[term] = money;
    }
}
