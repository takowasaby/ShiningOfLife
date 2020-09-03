using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScrollBehavior : MonoBehaviour
{
    public bool debugMode = false;

    public Text messageText;
    public RectTransform panel;

    public float scrollSpeed = 500f;

    private bool isScrolling;
    private Queue<string> messages = new Queue<string>();

    public void RequestScroll(string message)
    {
        this.messages.Enqueue(message);
    }

    private void Update()
    {
        if (this.debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                this.RequestScroll("Estuans interius ira vehementi");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.RequestScroll("Sephiroth!");
            }
        }

        if (this.isScrolling)
        {
            this.Scroll();
        }
        else if (this.messages.Count > 0)
        {
            this.StartScrolling(this.messages.Dequeue());
        }
    }

    private void Scroll()
    {
        var currentPos = this.messageText.rectTransform.anchoredPosition;
        if (this.messageText.rectTransform.offsetMax.x < -this.panel.rect.width)
        {
            var startPos = new Vector2(0f, currentPos.y);
            this.messageText.rectTransform.anchoredPosition = startPos;
            this.isScrolling = false;
        }
        else
        {
            var nextPos = new Vector2(currentPos.x - (this.scrollSpeed * Time.deltaTime), currentPos.y);
            this.messageText.rectTransform.anchoredPosition = nextPos;
        }
    }

    private void StartScrolling(string message)
    {
        this.messageText.text = message;
        this.messageText.rectTransform.sizeDelta = new Vector2(this.messageText.preferredWidth, this.messageText.rectTransform.sizeDelta.y);
        this.isScrolling = true;
    }
}
