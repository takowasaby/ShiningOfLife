using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    [SerializeField] private MessageScrollBehavior scrollBehaviour;
    [SerializeField] private CommandOpenness commandOpenness;
    [SerializeField] private MoneyProgress moneyProgress;
    [SerializeField] private SatisfactionProgress satisfactionProgress;
    [SerializeField] private UserCountProgress userCountProgress;
    //[SerializeField] private FirstNotice firstNotice;
    [SerializeField] private TermProgress termProgress;

    [SerializeField] private List<long> moneyNoticeThreshold;
    [SerializeField] private List<long> userNoticeThreshold;
    [SerializeField] private List<long> satifiNoticeThreshold;

    // Start is called before the first frame update
    void Start()
    {
        //Startで通知するのは前の月の結果だよね？
        if (termProgress.currentTerm > 0)
        {
            
            NoticeUserMessage();
            NoticeSatifiMessage();
            NoticeMoneyMessage();
            NoticeOpenCommand();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NoticeMoneyMessage()
    {
        long nowMoney = moneyProgress.moneys[termProgress.currentTerm];
        long noticeMoney = 0;
        foreach (long moneyThreshold in moneyNoticeThreshold)
        {
            if (nowMoney >= moneyThreshold)
            {
                noticeMoney = moneyThreshold;
            }
        }

        if (noticeMoney != 0)
        {
            string message = "売り上げが" + noticeMoney.ToString() + "円を突破しました！";
            scrollBehaviour.RequestScroll(message);
        }

    }

    private void NoticeSatifiMessage()
    {
        float nowSatifi =satisfactionProgress.satisFactions[termProgress.currentTerm];
        float noticeSatifi = nowSatifi;
        /*
        foreach (float satifiThreshold in satifiNoticeThreshold)
        {
            if (nowSatifi >= satifiThreshold)
            {
                noticeSatifi = satifiThreshold;
            }
        }
        */

       
        string message = "好感度が" + nowSatifi.ToString() + "になりました！";
        if (noticeSatifi <= satifiNoticeThreshold[0])
        {
            message += " ユーザーは運営に対して殺意を持っています　サ終寸前です";
        }else if (noticeSatifi <= satifiNoticeThreshold[1])
        {
            message += " ユーザーは運営に対して大きな不満を持っています　危険な状態です";
        }
        else if(noticeSatifi <= satifiNoticeThreshold[2])
        {
            message += " ユーザーは運営に対して、少し不満を持っています";
        }
        else if (noticeSatifi <= satifiNoticeThreshold[3])
        {
            message += " ユーザーは運営を、普通に評価しています";
        }else if (noticeSatifi <= satifiNoticeThreshold[4])
        {
            message += " ユーザーは運営に対して好意的です";
        }
        else
        {
            message += " ユーザーは運営を神運営だと褒め称えています　ほぼ信者です";
        }

        scrollBehaviour.RequestScroll(message);
        
    }

    private void NoticeUserMessage()
    {
        long nowUser = userCountProgress.MukakinUserCounts[termProgress.currentTerm]
            + userCountProgress.BikakinUserCounts[termProgress.currentTerm]
            + userCountProgress.TyukakinUserCounts[termProgress.currentTerm]
            + userCountProgress.JukakinUserCounts[termProgress.currentTerm]
            + userCountProgress.SekiyuoCounts[termProgress.currentTerm];
            
        long noticeUser = 0;
        foreach (long userThreshold in userNoticeThreshold)
        {
            if (nowUser >= userThreshold)
            {
                noticeUser = userThreshold;
            }
        }

        if (noticeUser == 0) return;

        string message = "ユーザー数が" + noticeUser.ToString() + "人を突破しました！";
        scrollBehaviour.RequestScroll(message);

        if (userCountProgress.SekiyuoCounts[termProgress.currentTerm] > 0)
        {
            string sekiyuMessage = "石油王が" + userCountProgress.SekiyuoCounts[termProgress.currentTerm] + "人遊んでいます！";
            scrollBehaviour.RequestScroll(sekiyuMessage);
        }
    }

    private void NoticeOpenCommand()
    {
        if (commandOpenness.CompleteGacha)
        {
            string compMess = "コンプリートガチャを開放可能です！";
            scrollBehaviour.RequestScroll(compMess);
        }

        if (commandOpenness.HukubukuroGacha)
        {
            string hukuMess = "福袋ガチャを開放可能です！";
            scrollBehaviour.RequestScroll(hukuMess);
        }

        if (commandOpenness.ConfirmGacha)
        {
            string compMess = "ボックスガチャを開放可能です！";
            scrollBehaviour.RequestScroll(compMess);
        }

        if (commandOpenness.Update)
        {
            string compMess = "アップデートを実施可能です！";
            scrollBehaviour.RequestScroll(compMess);
        }

        if (commandOpenness.StoneDistribution)
        {
            string compMess = "詫び石の配布が可能です！";
            scrollBehaviour.RequestScroll(compMess);
        }

        if (commandOpenness.Ceiling)
        {
            string compMess = "天井の追加が可能です！";
            scrollBehaviour.RequestScroll(compMess);
        }
    }
}
