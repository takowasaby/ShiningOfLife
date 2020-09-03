using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehavior : MonoBehaviour
{
    public Button button;
    public Image lockImage;

    public void Lock()
    {
        this.button.interactable = false;
        this.lockImage.enabled = true;
    }

    public void Unlock()
    {
        this.button.interactable = true;
        this.lockImage.enabled = false;
    }
}
