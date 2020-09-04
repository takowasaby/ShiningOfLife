using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GachaCalculator : MonoBehaviour
{
    public CalculationHalfway Calc(CalculationHalfway halfway)
    {
        // それぞれのガチャの効果を算出
        // 例）ノーマルガチャなら好感度を変更

        // ついでにガチャ確率から個別にKindnessを割り出す
        // 最高レアが10%（最も優しい）->6%（優しい）->1%（厳しい）->0.01%（最も厳しい）

        // 個別のKindnessを平均して総合Kindnessを算出

        var kindnesses = new float[6];

        // ノーマルガチャ
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.Normal))
        {
            var normalGachaparam = halfway.playerInput.gachaParams[GachaCategory.Normal];
            kindnesses[0] = Mathf.Log10(Mathf.Clamp(normalGachaparam.rates.rates[GachaRarity.LR], 0.1f, 10f));
            halfway.innerInput.satisfaction.value += kindnesses[0] * 1f;
            halfway.innerInput.satisfaction.value += 4f;
        }

        // プレミアム
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.Premium))
        {
            var premiumGachaparam = halfway.playerInput.gachaParams[GachaCategory.Premium];
            kindnesses[1] = Mathf.Log10(Mathf.Clamp(premiumGachaparam.rates.rates[GachaRarity.LR], 0.1f, 10f));
            halfway.imValues.bonusRate += kindnesses[1] * 0.2f;
        }

        // ボックス
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.Box))
        {
            var boxGachaparam = halfway.playerInput.gachaParams[GachaCategory.Box];
            kindnesses[2] = Mathf.Log10(Mathf.Clamp(boxGachaparam.rates.rates[GachaRarity.LR], 0.1f, 10f));
            halfway.innerInput.satisfaction.value += kindnesses[0] * 6f;
        }

        // コンプ
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.Complete))
        {
            var completeGachaparam = halfway.playerInput.gachaParams[GachaCategory.Complete];
            kindnesses[3] = Mathf.Log10(Mathf.Clamp(completeGachaparam.rates.rates[GachaRarity.LR], 0.1f, 10f));
            halfway.imValues.bonusRate -= kindnesses[1];
            halfway.innerInput.satisfaction.value -= 10f;
        }

        // 確定
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.Confirm))
        {
            var confirmGachaparam = halfway.playerInput.gachaParams[GachaCategory.Confirm];
            kindnesses[4] = 1f;
            halfway.imValues.bonusRate -= 0.1f;
            halfway.innerInput.satisfaction.value += 3f;
        }

        // 福袋
        if (halfway.playerInput.gachaParams.ContainsKey(GachaCategory.LuckyBag))
        {
            var luckyBagGachaparam = halfway.playerInput.gachaParams[GachaCategory.LuckyBag];
            kindnesses[5] = 1f;
            halfway.imValues.bonusRate += 0.5f;
            halfway.innerInput.satisfaction.value += 6f;
        }

        halfway.imValues.kindness = kindnesses.Average();

        return halfway;
    }
}
