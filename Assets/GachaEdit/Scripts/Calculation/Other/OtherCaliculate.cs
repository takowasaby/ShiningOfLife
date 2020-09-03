using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCaliculate : MonoBehaviour
{

    public static 
    // Start is called before the first frame update
    void Start()
    {
        //詫び石
        if(stoneDistrib > 0){
            satisfaction += stoneDistrib/20;
            bonusrate -= stonecost;
        }

        //プロモ
        if(cost > 0){
            UserSegment[target] += UserSegment[target];
        }
        
        //アップデート
        if(updating == 1){
            cellingad = 1;
            satisfaction += 10;
            bonusrate += 0.5;
            expenditure += updatecost;
        }
    }

    void Update()
    {

    }

}
