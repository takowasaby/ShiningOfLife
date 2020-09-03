using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundBehavior : MonoBehaviour
{
    public CanvasScaler canvas;
    public Image backGround;

    public float scrollPeriod = 3f;

    private void Update()
    {
        var dir = new Vector2(this.canvas.referenceResolution.x, -this.canvas.referenceResolution.y);
        var speed = dir / this.scrollPeriod;
        this.backGround.rectTransform.anchoredPosition = this.backGround.rectTransform.anchoredPosition + speed * Time.deltaTime;
        if (this.backGround.rectTransform.anchoredPosition.x > dir.x / 2f || this.backGround.rectTransform.anchoredPosition.y < dir.y / 2f)
        {
            this.backGround.rectTransform.anchoredPosition = this.backGround.rectTransform.anchoredPosition - (dir / 4.2f);
        }
    }
}
