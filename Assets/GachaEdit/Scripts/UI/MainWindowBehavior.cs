using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWindowBehavior : MonoBehaviour
{
    public MenuButtonBehavior updateButton;
    public MenuButtonBehavior stoneDestinationButton;

    public CommandOpenness commandOpenness;

    private void Update()
    {
        if (this.commandOpenness.Update)
        {
            this.updateButton.Unlock();
        }
        else
        {
            this.updateButton.Lock();
        }

        if (this.commandOpenness.StoneDistribution)
        {
            this.stoneDestinationButton.Unlock();
        }
        else
        {
            this.stoneDestinationButton.Lock();
        }
    }
}
