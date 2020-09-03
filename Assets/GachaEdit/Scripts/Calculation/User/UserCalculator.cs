using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCalculator : MonoBehaviour
{
    public CalculationHalfway Calc(CalculationHalfway halfway)
    {
        var tyuKakin = halfway.innerInput.userCount.counts[UserSegment.TyuKakin];
        var biKakin = halfway.innerInput.userCount.counts[UserSegment.BiKakin];
        var mukakin = halfway.innerInput.userCount.counts[UserSegment.MuKakin];
        var satisfaction = halfway.innerInput.satisfaction.value;
        var kindness = halfway.imValues.kindness;

        halfway.innerInput.userCount.counts[UserSegment.JuKakin] += (long)(tyuKakin * (satisfaction / 500f * (1f - kindness / 5f)));
        halfway.innerInput.userCount.counts[UserSegment.TyuKakin] = (long)(((long)(tyuKakin + (1 - satisfaction / 500f)) + (long)(biKakin * (satisfaction / 200f))) * (1f - kindness / 10f));
        halfway.innerInput.userCount.counts[UserSegment.BiKakin] = (long)(((long)(biKakin + (1 - satisfaction / 200f)) + (long)(mukakin * (satisfaction / 100f))) * (1f + kindness / 10f));
        halfway.innerInput.userCount.counts[UserSegment.MuKakin] += (long)(mukakin * (satisfaction / 50f * (1 + kindness / 20f)));

        if (satisfaction == 100f)
        {
            halfway.innerInput.userCount.counts[UserSegment.Sekiyuo] += 1;
        }

        return halfway;
    }
}
