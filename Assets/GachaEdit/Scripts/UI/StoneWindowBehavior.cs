using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneWindowBehavior : MonoBehaviour
{
    public PlayerInputCollectorBehavior collector;
    public Slider slider;

    public void ChangeNumberOfStone()
    {
        this.collector.playerInput.stoneDistrib.rate = this.slider.value;
    }
}
