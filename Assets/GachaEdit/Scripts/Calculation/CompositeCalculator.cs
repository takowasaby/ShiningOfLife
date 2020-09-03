using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeCalculator : MonoBehaviour
{
    public bool debugMode;

    public GachaCalculator gachaCalculator;
    public OtherCalculator otherCalculator;
    public UserCalculator userCalculator;
    public BasicCalculator basicCalculator;

    public CalculationHalfway Calc(CalculationHalfway halfway)
    {
        var h0 = this.gachaCalculator.Calc(halfway);
        var h1 = this.gachaCalculator.Calc(h0);
        var h2 = this.gachaCalculator.Calc(h1);
        return this.gachaCalculator.Calc(h2);
    }
}
