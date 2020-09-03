using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/OtherProgress")]
public class OtherProgress : ScriptableObject
{
    public List<long> gachaCounts = new List<long>();

    public void SaveProgress(long count, int term)
    {
        for (var i = this.gachaCounts.Count; i < term + 1; i++)
        {
            this.gachaCounts.Add(0L);
        }

        this.gachaCounts[term] = count;
    }
}
