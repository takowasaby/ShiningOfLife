using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeaderBehavior : MonoBehaviour
{
    public bool debugMode;

    public Text termText;
    public Text userCountText;
    public Text satisfactionValueText;
    public Text incomeValueText;

    public TermProgress termProgress;
    public UserCountProgress userCountProgress;
    public SatisfactionProgress satisfactionProgress;
    public MoneyProgress moneyProgress;

    public string[] untis = new string[0];

    private void Update()
    {
        if (this.debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var last = this.userCountProgress.MukakinUserCounts.Last();
                last = last * 10 + 1;
                this.userCountProgress.MukakinUserCounts.Add(last);
                last += 1;
                this.userCountProgress.BikakinUserCounts.Add(last);
                last += 1;
                this.userCountProgress.TyukakinUserCounts.Add(last);
                last += 1;
                this.userCountProgress.JukakinUserCounts.Add(last);
                last += 1;
                this.userCountProgress.SekiyuoCounts.Add(last);
            }
        }

        this.UpdateTermText();
        this.UpdateUserCountText();
        this.UpdateSatisfactionValueText();
        this.UpdateIncomeValueText();
    }

    private void UpdateTermText()
    {
        this.termText.text = this.termProgress.CurrentTermName();
    }

    private void UpdateUserCountText()
    {
        var userCoutString = "";

        userCoutString += $"無課金 {CreateUnitString(this.userCountProgress.MukakinUserCounts.Last(), this.untis)}人";
        userCoutString += $"　微課金 {CreateUnitString(this.userCountProgress.BikakinUserCounts.Last(), this.untis)}人";

        if (this.userCountProgress.SekiyuoCounts.Last() > 0)
        {
            userCoutString += $"\n<color=#ec5353>石油王 {CreateUnitString(this.userCountProgress.SekiyuoCounts.Last(), this.untis)}人</color>";
        }

        userCoutString += $"\n中課金 {CreateUnitString(this.userCountProgress.TyukakinUserCounts.Last(), this.untis)}人";
        userCoutString += $"　重課金 {CreateUnitString(this.userCountProgress.JukakinUserCounts.Last(), this.untis)}人";

        this.userCountText.text = userCoutString;
    }

    private void UpdateSatisfactionValueText()
    {
        this.satisfactionValueText.text = $"{this.satisfactionProgress.satisFactions.Last():000.00}";
    }

    private void UpdateIncomeValueText()
    {
        this.incomeValueText.text = $"{CreateUnitString(this.moneyProgress.moneys.Last(), this.untis)}円";
    }

    private static string CreateUnitString(long value, string[] units)
    {
        if (value < 1000000L)
        {
            return $"{value:000000}";
        }
        var unitValue = 1L;
        for (var i = 0; i < units.Length; i++)
        {
            unitValue *= 10000;
            var viewValue = value / unitValue;
            if (viewValue < 10000)
            {
                return $"{viewValue:0000}{units[i]}";
            }
        }
        if (units.Length > 0)
        {
            return $"{value}{units.Last()}";
        }
        return "-error-";
    }
}
