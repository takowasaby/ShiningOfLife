using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GachaRarity
{
    N,
    R,
    SR,
    SSR,
    UR,
    LR,
}

public enum UserSegment
{
    MuKakin,
    BiKakin,
    TyuKakin,
    JuKakin,
    Sekiyuo,
}

public struct GachaRatios
{
    public Dictionary<GachaRarity, float> ratios;
}

public struct GachaCeiling
{
    public int value;
}

public struct GachaParameter
{
    public GachaRatios ratios;
    public GachaCeiling ceiling;
}

public struct StoneDistribution
{
    public int count;
}

public struct PromotionCost
{
    public long cost;
}

public struct UserCount
{
    public Dictionary<UserSegment, long> ratios;
}

public struct UserSatisfaction
{
    public float value;
}

public struct MoneyBalance
{
    public long income;
    public long expenditure;
}


public struct PlayerInput
{
    public GachaParameter gachaParam;
    public StoneDistribution stoneDistrib;
    public PromotionCost promoConst;
}

public struct InnerInput
{
    public UserCount userCount;
    public UserSatisfaction satisfaction;
}

public struct GraphOutput
{
    public UserCount userCount;
    public UserSatisfaction satisfaction;
    public MoneyBalance balance;
}
