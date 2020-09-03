using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicCalculation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        barance += income - expenditure;
        barance *= bonusrate;

        bonusrate = 1.0;
        updating = 0;
        updatecost = 0;

    }
}


