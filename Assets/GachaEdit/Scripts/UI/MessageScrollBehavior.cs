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
                this.RequestScroll("滲み出す混濁の紋章 不遜なる狂気の器 湧き上がり・否定し・痺れ・瞬き・眠りを妨げる 爬行(はこう)する鉄の王女 絶えず自壊する泥の人形 結合せよ 反発せよ 地に満ち 己の無力を知れ破道の九十・黒棺");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.RequestScroll("千手の涯 届かざる闇の御手 映らざる天の射手 光を落とす道 火種を煽る風 集いて惑うな我が指を見よ 光弾・八身・九条・天経・疾宝・大輪・灰色の砲塔 弓引く彼方 皎皎として消ゆ");
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
