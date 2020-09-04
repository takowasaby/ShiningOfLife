using UnityEngine;
using System.Collections;
using System.Collections.Generic; // for List<>

public class GenerateLR : MonoBehaviour
{

    [SerializeField] private GameObject MoneyLineGroup; // for grouping
    [SerializeField] private GameObject SatifiLineGroup;
    [SerializeField] private GameObject UserLineGroup;

    [SerializeField] private Material money_material;
    [SerializeField] private Material satifi_material;

    [SerializeField] private Material mukakin_material;
    [SerializeField] private Material bikakin_material;
    [SerializeField] private Material tyukakin_material;
    [SerializeField] private Material jukakin_material;
    [SerializeField] private Material sekiyuou_material;


    [SerializeField] private AnimationCurve curve;
    [SerializeField] private MoneyProgress moneyProgress;
    [SerializeField] private SatisfactionProgress satisfactionProgress;
    [SerializeField] private UserCountProgress userCountProgress; 

    private float count = 0;
    private int idxAll;
    private bool isAllClose = false;

    List<Vector2> my2DPoint_money = new List<Vector2>();
    List<Vector2> my2DPoint_satifi = new List<Vector2>();

    List<Vector2> my2DPoint_mu = new List<Vector2>();
    List<Vector2> my2DPoint_bi = new List<Vector2>();
    List<Vector2> my2DPoint_tyu = new List<Vector2>();
    List<Vector2> my2DPoint_ju = new List<Vector2>();
    List<Vector2> my2DPoint_seki = new List<Vector2>();

    private int selectTab = 0;//0=money,1=satification,2=user

    void DrawLine(List<Vector2> my2DVec, int startPos, Material material, GameObject parent)
    {
        List<Vector2> myPoint = new List<Vector2>();
        for (int idx = 0; idx < 2; idx++)
        {
            myPoint.Add(new Vector3(my2DVec[startPos + idx].x, my2DVec[startPos + idx].y, 0.0f));
        }

        GameObject newLine = new GameObject("Line" + startPos.ToString());
        LineRenderer lRend = newLine.AddComponent<LineRenderer>();
        lRend.material = material;
        lRend.widthCurve = curve;
        lRend.SetVertexCount(2);
        Vector3 startVec = myPoint[0];
        Vector3 endVec = myPoint[1];
        lRend.SetPosition(0, startVec);
        lRend.SetPosition(1, endVec);

        newLine.transform.parent = parent.transform; // for grouping
    }

    void Start()
    {

        Vector2 pos_Money = new Vector2(MoneyLineGroup.transform.position.x, MoneyLineGroup.transform.position.y);
        Vector2 pos_Satifi = new Vector2(SatifiLineGroup.transform.position.x, SatifiLineGroup.transform.position.y);
        Vector2 pos_User = new Vector2(UserLineGroup.transform.position.x, UserLineGroup.transform.position.y);

        int money_rate = 100000000;//yosinanikaeru
        int satifi_rate = 1;
        int user_rate = 50000;

        float unit = 40f;

        for (int idx = 0; idx < moneyProgress.moneys.Count; idx++)
        {      
            my2DPoint_money.Add(pos_Money+new Vector2(unit * idx, (float)moneyProgress.moneys[idx]/money_rate));
        }
        my2DPoint_money.Add(pos_Money + new Vector2(unit * 12, (float)moneyProgress.moneys[moneyProgress.moneys.Count-1] / money_rate));

        for (int idx = 0; idx < satisfactionProgress.satisFactions.Count; idx++)
        {
            my2DPoint_satifi.Add(pos_Satifi + new Vector2(unit * idx, (float)satisfactionProgress.satisFactions[idx] / satifi_rate));
        }
        my2DPoint_satifi.Add(pos_Satifi + new Vector2(unit * 12, (float)satisfactionProgress.satisFactions[satisfactionProgress.satisFactions.Count-1] / satifi_rate));

        for (int idx = 0; idx < userCountProgress.MukakinUserCounts.Count; idx++)
        {
            my2DPoint_mu.Add(pos_User+ new Vector2(unit * idx, (float)userCountProgress.MukakinUserCounts[idx] / user_rate));
        }
        my2DPoint_mu.Add(pos_User + new Vector2(unit * 12, (float)userCountProgress.MukakinUserCounts[userCountProgress.MukakinUserCounts.Count-1] / user_rate));

        for (int idx = 0; idx < userCountProgress.BikakinUserCounts.Count; idx++)
        {
            my2DPoint_bi.Add(pos_User + new Vector2(unit * idx, (float)userCountProgress.BikakinUserCounts[idx] / user_rate));
        }
        my2DPoint_bi.Add(pos_User + new Vector2(unit * 12, (float)userCountProgress.BikakinUserCounts[userCountProgress.BikakinUserCounts.Count-1] / user_rate));

        for (int idx = 0; idx < userCountProgress.TyukakinUserCounts.Count; idx++)
        {
            my2DPoint_tyu.Add(pos_User + new Vector2(unit * idx, (float)userCountProgress.TyukakinUserCounts[idx] / user_rate));
        }
        my2DPoint_tyu.Add(pos_User + new Vector2(unit * 12, (float)userCountProgress.TyukakinUserCounts[userCountProgress.TyukakinUserCounts.Count-1] / user_rate));

        for (int idx = 0; idx < userCountProgress.JukakinUserCounts.Count; idx++)
        {
            my2DPoint_ju.Add(pos_User + new Vector2(unit * idx, (float)userCountProgress.JukakinUserCounts[idx] / user_rate));
        }
        my2DPoint_ju.Add(pos_User + new Vector2(unit * 12, (float)userCountProgress.JukakinUserCounts[userCountProgress.JukakinUserCounts.Count-1] / user_rate));

        for (int idx = 0; idx < userCountProgress.SekiyuoCounts.Count; idx++)
        {
            my2DPoint_seki.Add(pos_User + new Vector2(unit * idx, (float)userCountProgress.SekiyuoCounts[idx] / user_rate));
        }
        my2DPoint_seki.Add(pos_User + new Vector2(unit * 12, (float)userCountProgress.SekiyuoCounts[userCountProgress.SekiyuoCounts.Count-1] / user_rate));

        /*
        for (int idx = 0; idx < my2DPoint.Count - 1; idx++)
        {
            DrawLine(my2DPoint, idx);
        }
        */

        SelectMoney();
    }

    void Update()
    {
        count += Time.deltaTime;

        if (count >= 0.5f)
        {
            
            

            if (idxAll < my2DPoint_money.Count-2 )
            {
                DrawLine(my2DPoint_money, idxAll, money_material,MoneyLineGroup);
                DrawLine(my2DPoint_satifi, idxAll, satifi_material,SatifiLineGroup);

                DrawLine(my2DPoint_mu, idxAll, mukakin_material, UserLineGroup);
                DrawLine(my2DPoint_bi, idxAll, bikakin_material, UserLineGroup);
                DrawLine(my2DPoint_tyu, idxAll, tyukakin_material, UserLineGroup);
                DrawLine(my2DPoint_ju, idxAll, jukakin_material, UserLineGroup);
                DrawLine(my2DPoint_seki, idxAll, sekiyuou_material, UserLineGroup);

                idxAll++;
            }
            else
            {         
                //idxAll = 0;
            }
            count = 0;
            
        }
    }

    public void SelectMoney()
    {
        selectTab = 0;

        MoneyLineGroup.SetActive(true);
        SatifiLineGroup.SetActive(false);
        UserLineGroup.SetActive(false);
    }

    public void SelectSatification()
    {
        selectTab = 1;

        MoneyLineGroup.SetActive(false);
        SatifiLineGroup.SetActive(true);
        UserLineGroup.SetActive(false);
    }

    public void SelectUser()
    {
        selectTab = 2;

        MoneyLineGroup.SetActive(false);
        SatifiLineGroup.SetActive(false);
        UserLineGroup.SetActive(true);
    }

    public void AllClose()
    {
        if (isAllClose)
        {
            ReOpen();
            isAllClose = false;
        }
        else
        {
            MoneyLineGroup.SetActive(false);
            SatifiLineGroup.SetActive(false);
            UserLineGroup.SetActive(false);
            isAllClose = true;
        }
        
    }

    private void ReOpen()
    {
        if (selectTab == 0)
        {
            SelectMoney();
        }
        else if (selectTab == 1)
        {
            SelectSatification();
        }
        else if (selectTab == 2)
        {
            SelectUser();
        }
    }
}