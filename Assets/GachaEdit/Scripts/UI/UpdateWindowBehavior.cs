using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWindowBehavior : MonoBehaviour
{
    public PlayerInputCollectorBehavior collector;
    public Dropdown dropDown;

    public void ChangePromotion()
    {
        switch (this.dropDown.value)
        {
            case 0:
                this.collector.playerInput.updates =  new Update[0];
                break;
            case 1:
                this.collector.playerInput.updates = new Update[] { new Update { target = UpdateTarget.CompleteGacha } };
                break;
            case 2:
                this.collector.playerInput.updates = new Update[] { new Update { target = UpdateTarget.Ceiling } };
                break;
        }
    }
}
