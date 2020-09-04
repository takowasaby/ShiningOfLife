using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCalculator : MonoBehaviour
{
    public float stoneCostRateDecreaseMax = 0.3f;
    public long updateCost = 1000000;

    public CalculationHalfway Calc(CalculationHalfway halfway)
    {
        //詫び石
        var stoneDistRate = halfway.playerInput.stoneDistrib.rate;

        if (stoneDistRate > 0.0f)
        {
            halfway.innerInput.satisfaction.value += (float)stoneDistRate * 5f;
            halfway.imValues.bonusRate -= this.stoneCostRateDecreaseMax * stoneDistRate;
        }

        //プロモ
        var promotion = halfway.playerInput.promotions;
        if (promotion.cost > 0L)
        {
            halfway.innerInput.userCount.counts[promotion.target] += halfway.innerInput.userCount.counts[promotion.target] / 3;
            halfway.graphOutput.balance.expenditure += promotion.cost;
        }

        //アップデート
        foreach (var update in halfway.playerInput.updates)
        {
            halfway.graphOutput.opness.opens = new UpdateTarget[] { update.target };
            halfway.innerInput.satisfaction.value += 10f;
            halfway.imValues.bonusRate += 0.5f;
            halfway.graphOutput.balance.expenditure += this.updateCost;
        }

        halfway.innerInput.satisfaction.value = Mathf.Clamp(halfway.innerInput.satisfaction.value, 0f, 100f);

        return halfway;
    }
}
