using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasicCalculator : MonoBehaviour
{
    public CalculationHalfway Calc(CalculationHalfway halfway)
    {
        // ユーザー数からIncomeを計算（Ceilingも反映）
        // BounusRateを清算

        // 順番はGachaCalculator、OtherCalculator、UserCalculator、BasicCalculator

        var userCounts = halfway.innerInput.userCount.counts;
        var ceilingCount = halfway.playerInput.gachaParams
            .Where(param => param.Value.isCeiling)
            .Count();
        
        var income =
            userCounts[UserSegment.BiKakin] * 1000L +
            (long)(userCounts[UserSegment.TyuKakin] * 10000L * (1 + ceilingCount * 0.1)) +
            (long)(userCounts[UserSegment.JuKakin] * 50000L * (1 - ceilingCount * 0.1)) +
            userCounts[UserSegment.Sekiyuo] * 1000000L;

        halfway.graphOutput.balance.income = (long)(income * halfway.imValues.bonusRate);

        return halfway;
    }
}


