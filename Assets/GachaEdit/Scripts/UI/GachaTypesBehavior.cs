using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GachaTypesBehavior : MonoBehaviour
{
    public GachaSelectBehavior gachaSelectBehavior;
    public CommandOpenness commandOpenness;

    public Button normalGachaButton;
    public Button premiumGachaButton;
    public Button boxGachaButton;
    public Button completeGachaButton;
    public Button luckyBagGachaButton;
    public Button confirmGachaButton;

    public GachaCategory select;

    private Dictionary<GachaCategory, Button> buttons;

    private void Awake()
    {
        this.buttons = new Dictionary<GachaCategory, Button>
        {
            { GachaCategory.Normal, this.normalGachaButton },
            { GachaCategory.Premium, this.premiumGachaButton },
            { GachaCategory.Box, this.boxGachaButton },
            { GachaCategory.Complete, this.completeGachaButton },
            { GachaCategory.LuckyBag, this.luckyBagGachaButton },
            { GachaCategory.Confirm, this.confirmGachaButton },
        };
    }

    private void Start()
    {
        foreach (var kv in this.buttons)
        {
            kv.Value.onClick.AddListener(() => this.SelectButton(kv.Key));
        }

        this.buttons[GachaCategory.Normal].interactable = false;
        this.select = GachaCategory.Normal;
    }

    private void Update()
    {
        this.completeGachaButton.gameObject.SetActive(this.commandOpenness.CompleteGacha);
        this.luckyBagGachaButton.gameObject.SetActive(this.commandOpenness.HukubukuroGacha);
        this.confirmGachaButton.gameObject.SetActive(this.commandOpenness.ConfirmGacha);
    }

    private void SelectButton(GachaCategory type)
    {
        this.gachaSelectBehavior.ChangeGachaType(this.select, type);
        this.buttons[select].interactable = true;
        this.buttons[type].interactable = false;
        this.select = type;
    }
}
