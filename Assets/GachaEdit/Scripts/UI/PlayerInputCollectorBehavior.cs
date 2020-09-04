using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCollectorBehavior : MonoBehaviour
{
    public PlayerInput playerInput;

    public CommandOpenness commandOpenness;

    private void Awake()
    {
        this.playerInput = new PlayerInput();

        var defaultGachaParam = new GachaParameter
        {
            rates = new GachaRates
            {
                rates = new Dictionary<GachaRarity, float>
                        {
                            { GachaRarity.N, 100f },
                            { GachaRarity.R, 0f },
                            { GachaRarity.SR, 0f },
                            { GachaRarity.SSR, 0f },
                            { GachaRarity.UR, 0f },
                            { GachaRarity.LR, 0f },
                        }
            },
            isCeiling = false
        };

        this.playerInput.gachaParams = new Dictionary<GachaCategory, GachaParameter>();

        this.playerInput.gachaParams[GachaCategory.Normal] = defaultGachaParam;
        this.playerInput.gachaParams[GachaCategory.Premium] = defaultGachaParam;
        this.playerInput.gachaParams[GachaCategory.Box] = defaultGachaParam;
        this.playerInput.gachaParams[GachaCategory.Complete] = defaultGachaParam;
        this.playerInput.gachaParams[GachaCategory.LuckyBag] = defaultGachaParam;
        this.playerInput.gachaParams[GachaCategory.Confirm] = defaultGachaParam;

        this.playerInput.updates = new Update[0];
    }

    public PlayerInput GetPlayerInput()
    {
        var ret = this.playerInput;
        ret.gachaParams = new Dictionary<GachaCategory, GachaParameter>(ret.gachaParams);
        if (!this.commandOpenness.CompleteGacha)
        {
            ret.gachaParams.Remove(GachaCategory.Complete);
        }
        if (!this.commandOpenness.HukubukuroGacha)
        {
            ret.gachaParams.Remove(GachaCategory.LuckyBag);
        }
        if (!this.commandOpenness.ConfirmGacha)
        {
            ret.gachaParams.Remove(GachaCategory.Confirm);
        }
        return ret;
    }
}
