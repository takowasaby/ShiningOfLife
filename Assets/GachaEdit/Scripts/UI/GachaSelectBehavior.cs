using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaSelectBehavior : MonoBehaviour
{
    // Ceilingを無効化
    // 呼び出し時にリロード
    // OK時の保存
    // ガチャ選択によっては天井と確率操作を無効に
    public PlayerInputCollectorBehavior collector;
    public CommandOpenness commandOpenness;

    public ChangeProbabilityBehavior changeProbabilityBehavior;
    public CanvasGroup changeProbabilityGroup;
    public Text ceilingTitle;
    public Toggle ceilingToggle;

    public void ChangeGachaType(GachaCategory before, GachaCategory after)
    {
        this.collector.playerInput.gachaParams[before] = new GachaParameter
        {
           rates = this.changeProbabilityBehavior.GetGachaRates(),
           isCeiling = this.ceilingToggle.isOn
        };
        this.changeProbabilityBehavior.Reload(this.collector.playerInput.gachaParams[after].rates);
        this.ceilingToggle.isOn = this.collector.playerInput.gachaParams[after].isCeiling;

        if (after == GachaCategory.Confirm || after == GachaCategory.LuckyBag)
        {
            this.changeProbabilityGroup.interactable = false;
            this.ceilingToggle.interactable = false;
        }
        else
        {
            this.changeProbabilityGroup.interactable = true;
            this.ceilingToggle.interactable = true;
        }
    }

    private void Start()
    {
        this.changeProbabilityBehavior.Reload(this.collector.playerInput.gachaParams[GachaCategory.Normal].rates);
        this.ceilingToggle.isOn = this.collector.playerInput.gachaParams[GachaCategory.Normal].isCeiling;
    }

    private void Update()
    {
        this.ceilingTitle.gameObject.SetActive(this.commandOpenness.Ceiling);
        this.ceilingToggle.gameObject.SetActive(this.commandOpenness.Ceiling);
    }
}
