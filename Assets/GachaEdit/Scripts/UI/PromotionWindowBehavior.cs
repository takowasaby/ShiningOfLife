using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromotionWindowBehavior : MonoBehaviour
{
    public PlayerInputCollectorBehavior collector;
    public Dropdown dropDown;

    public void ChangePromotion()
    {
        switch (this.dropDown.value)
        {
            case 0:
                this.collector.playerInput.promotions.cost = 0;
                break;
            case 1:
                this.collector.playerInput.promotions.target = UserSegment.MuKakin;
                this.collector.playerInput.promotions.cost = 1;
                break;
            case 2:
                this.collector.playerInput.promotions.target = UserSegment.BiKakin;
                this.collector.playerInput.promotions.cost = 1;
                break;
            case 3:
                this.collector.playerInput.promotions.target = UserSegment.TyuKakin;
                this.collector.playerInput.promotions.cost = 1;
                break;
            case 4:
                this.collector.playerInput.promotions.target = UserSegment.JuKakin;
                this.collector.playerInput.promotions.cost = 1;
                break;
        }
    }
}
