using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProbabilityBehavior : MonoBehaviour
{
    // 合計が100%になるように調整
    public InputField nField;
    public InputField rField;
    public InputField srField;
    public InputField ssrField;
    public InputField urField;
    public InputField lrField;

    private Dictionary<GachaRarity, InputField> fields;

    public GachaRates GetGachaRates()
    {
        return new GachaRates
        {
            rates = this.fields
                .ToDictionary(
                    kv => kv.Key,
                    kv => float.Parse(kv.Value.text)
                )
        };
    }

    public void Reload(GachaRates newRates)
    {
        foreach (var kv in this.fields)
        {
            kv.Value.text = newRates.rates[kv.Key].ToString();
        }
    }

    private void Awake()
    {
        this.fields = new Dictionary<GachaRarity, InputField>
        {
            { GachaRarity.N, this.nField },
            { GachaRarity.R, this.rField },
            { GachaRarity.SR, this.srField },
            { GachaRarity.SSR, this.ssrField },
            { GachaRarity.UR, this.urField },
            { GachaRarity.LR, this.lrField }
        };
    }

    private void Start()
    {
        foreach (var kv in this.fields)
        {
            kv.Value.onEndEdit.AddListener(s => this.ChangeProbability(kv.Key, float.Parse(s)));
        }
    }

    private void ChangeProbability(GachaRarity rarity, float value)
    {
        var otherValueSum = this.OtherVelueSum(rarity);
        if (value + otherValueSum > 100f)
        {
            this.fields[GachaRarity.N].text = 0f.ToString();
            this.fields[rarity].text = (100f - otherValueSum).ToString();
        }
        else
        {
            this.fields[GachaRarity.N].text = (100f - value - otherValueSum).ToString();
            this.fields[rarity].text = value.ToString();
        }
    }

    private float OtherVelueSum(GachaRarity rarity)
    {
        return fields
            .Where(kv => kv.Key != rarity && kv.Key != GachaRarity.N)
            .Select(kv => kv.Value)
            .Select(field => float.Parse(field.text))
            .Sum();
    }
}
