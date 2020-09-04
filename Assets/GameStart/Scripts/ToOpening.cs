using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToOpening : MonoBehaviour
{
    // Start is called before the first frame update
    private float zikanSwitch = 0.0f;

    public CommandOpenness co;
    public MoneyProgress mp;
    public TermProgress tp;
    public SatisfactionProgress sp;
    public UserCountProgress ucp;
    public PremiumGachaRates pgr;

    void Start()
    {
        ucp.MukakinUserCounts = new List<long>();
        ucp.BikakinUserCounts = new List<long>();
        ucp.TyukakinUserCounts = new List<long>();
        ucp.JukakinUserCounts = new List<long>();
        ucp.SekiyuoCounts = new List<long>();

        tp.currentTerm = 0;

        mp.moneys = new List<long>();

        pgr.nRate = 100f;
        pgr.rRate = 0f;
        pgr.srRate = 0f;
        pgr.ssrRate = 0f;
        pgr.urRate = 0f;
        pgr.lrRate = 0f;

        sp.satisFactions = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        zikanSwitch += Time.deltaTime;
        if (Input.anyKeyDown && zikanSwitch > 1.5f)
        {
            SceneManager.LoadScene("Opening");
            
        }
    }
}
