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

public enum UpdateTarget
{
    CompleteGacha,
    Ceiling,
}

public enum GachaCategory
{
    Normal,
    Premium,
    Box,
    Complete,
    LuckyBag,
    Confirm,
}

public struct GachaRates
{
    public Dictionary<GachaRarity, float> rates;
}

public struct GachaParameter
{
    public GachaRates rates;
    public bool isCeiling;
}

public struct StoneDistribution
{
    public float rate;
}

public struct Promotion
{
    public long cost;
    public UserSegment target;
}

public struct Update
{
    public UpdateTarget target;
}

public struct UserCount
{
    public Dictionary<UserSegment, long> counts;
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

public struct UpdateOpness
{
    public UpdateTarget[] opens;
}

public struct PlayerInput
{
    public Dictionary<GachaCategory, GachaParameter> gachaParams;
    public StoneDistribution stoneDistrib;
    public Promotion promotions;
    public Update[] updates;
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
    public UpdateOpness opness;
}

public struct IntermediateValues
{
    public float kindness;
    public float bonusRate;
}

public struct CalculationHalfway
{
    public PlayerInput playerInput;
    public InnerInput innerInput;
    public GraphOutput graphOutput;
    public IntermediateValues imValues;
}
