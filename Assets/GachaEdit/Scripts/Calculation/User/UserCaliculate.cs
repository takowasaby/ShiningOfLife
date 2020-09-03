using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCaliculate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         JuKakin += TyuKakin*satisfaction / 500*(1-kindness/5);
         TyuKakin = ((TyuKakin*(1-satisfaction/500)) + BiKakin*satisfaction/200) * (1-kindness/10);
         BiKakin = ((BiKakin*(1-satisfaction/200)) + MuKakin*satisfaction/100) * (1+kindness/10);
         MuKakin += (MuKakin*satisfaction/50) * (1+kindness/20);
         if(satisfaction == 100){
            Sekiyuo += 1;
         }
    }

}
