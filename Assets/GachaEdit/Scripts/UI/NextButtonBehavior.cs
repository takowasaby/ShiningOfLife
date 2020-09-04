using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButtonBehavior : MonoBehaviour
{
    public PlayerInputCollectorBehavior playerInputCollector;
    public CompositeCalculator calculator;

    public MoneyProgress moneyProgress;
    public CommandOpenness commandOpenness;
    public UserCountProgress userCountProgress;
    public SatisfactionProgress satisfactionProgress;
    public TermProgress termProgress;
    public PremiumGachaRates premiumGachaRate;

    public void GoNext()
    {
        this.Simulation();
        Invoke("Aaa", 1f);
    }

    private void Aaa()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Simulation()
    {
        var playerInput = this.playerInputCollector.GetPlayerInput();

        var innerInput = new InnerInput
        {
            userCount = new UserCount
            {
                counts = new Dictionary<UserSegment, long>
                {
                    { UserSegment.MuKakin, this.userCountProgress.MukakinUserCounts.Last() },
                    { UserSegment.BiKakin, this.userCountProgress.BikakinUserCounts.Last() },
                    { UserSegment.TyuKakin, this.userCountProgress.TyukakinUserCounts.Last() },
                    { UserSegment.JuKakin, this.userCountProgress.JukakinUserCounts.Last() },
                    { UserSegment.Sekiyuo, this.userCountProgress.SekiyuoCounts.Last() }
                }
            },
            satisfaction = new UserSatisfaction
            {
                value = this.satisfactionProgress.satisFactions.Last()
            }
        };

        var graphOutput = new GraphOutput();

        var imValues = new IntermediateValues
        {
            kindness = 0f,
            bonusRate = 1f
        };

        var calculationHalfway = new CalculationHalfway
        {
            playerInput = playerInput,
            innerInput = innerInput,
            graphOutput = graphOutput,
            imValues = imValues
        };

        var result = this.calculator.Calc(calculationHalfway);

        // Update Progresses
        var profit = result.graphOutput.balance.income - result.graphOutput.balance.expenditure;
        this.moneyProgress.moneys.Add(this.moneyProgress.moneys.Last() + profit);

        var opens = result.graphOutput.opness.opens;
        if (opens != null)
        {
            this.commandOpenness.Ceiling = opens.Contains(UpdateTarget.Ceiling);
            this.commandOpenness.CompleteGacha = opens.Contains(UpdateTarget.CompleteGacha);
        }

        this.userCountProgress.MukakinUserCounts.Add(result.innerInput.userCount.counts[UserSegment.MuKakin]);
        this.userCountProgress.BikakinUserCounts.Add(result.innerInput.userCount.counts[UserSegment.BiKakin]);
        this.userCountProgress.TyukakinUserCounts.Add(result.innerInput.userCount.counts[UserSegment.TyuKakin]);
        this.userCountProgress.JukakinUserCounts.Add(result.innerInput.userCount.counts[UserSegment.JuKakin]);
        this.userCountProgress.SekiyuoCounts.Add(result.innerInput.userCount.counts[UserSegment.Sekiyuo]);

        this.satisfactionProgress.satisFactions.Add(result.innerInput.satisfaction.value);

        this.termProgress.currentTerm++;

        if (this.termProgress.currentTerm % 4 == 0)
        {
            this.commandOpenness.ConfirmGacha = true;
        }
        else
        {
            this.commandOpenness.ConfirmGacha = false;
        }

        if (this.termProgress.currentTerm % 5 == 0)
        {
            this.commandOpenness.Update = true;
        }
        else
        {
            this.commandOpenness.Update = false;
        }

        if (this.termProgress.currentTerm == 9)
        {
            this.commandOpenness.HukubukuroGacha = true;
        }
        else
        {
            this.commandOpenness.HukubukuroGacha = false;
        }

        if (this.satisfactionProgress.satisFactions.Last() < 5f)
        {
            this.commandOpenness.StoneDistribution = true;
        }
        else
        {
            this.commandOpenness.StoneDistribution = false;
        }

        // Save Premium Gacha rates
        var premiumRates = playerInput.gachaParams[GachaCategory.Premium].rates;
        this.premiumGachaRate.nRate = premiumRates.rates[GachaRarity.N];
        this.premiumGachaRate.rRate = premiumRates.rates[GachaRarity.R];
        this.premiumGachaRate.srRate = premiumRates.rates[GachaRarity.SR];
        this.premiumGachaRate.ssrRate = premiumRates.rates[GachaRarity.SSR];
        this.premiumGachaRate.urRate = premiumRates.rates[GachaRarity.UR];
        this.premiumGachaRate.lrRate = premiumRates.rates[GachaRarity.LR];
    }
}
