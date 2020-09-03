using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/TermProgress")]
public class TermProgress : ScriptableObject
{
    public int currentTerm;
    public string[] termNames;

    public string CurrentTermName()
    {
        return this.termNames[this.currentTerm];
    }
}
