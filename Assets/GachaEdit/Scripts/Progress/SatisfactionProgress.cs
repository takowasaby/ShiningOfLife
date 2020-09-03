using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/SatisfactionProgress")]
public class SatisfactionProgress : ScriptableObject
{
    public List<float> satisFactions = new List<float>();

    public void SaveProgress(float satisfaction, int term)
    {
        for (var i = this.satisFactions.Count; i < term + 1; i++)
        {
            this.satisFactions.Add(0f);
        }

        this.satisFactions[term] = satisfaction;
    }
}
