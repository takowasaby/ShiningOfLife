using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/UserCountProgress")]
public class UserCountProgress : ScriptableObject
{
    public List<long> MukakinUserCounts = new List<long>();
    public List<long> BikakinUserCounts = new List<long>();
    public List<long> TyukakinUserCounts = new List<long>();
    public List<long> JukakinUserCounts = new List<long>();
    public List<long> SekiyuoCounts = new List<long>();

    public void SaveProgress(UserSegment userSegment, long count, int term)
    {
        List<long> countList;
        switch (userSegment)
        {
            case UserSegment.MuKakin:
                countList = this.MukakinUserCounts;
                break;
            case UserSegment.BiKakin:
                countList = this.BikakinUserCounts;
                break;
            case UserSegment.TyuKakin:
                countList = this.TyukakinUserCounts;
                break;
            case UserSegment.JuKakin:
                countList = this.JukakinUserCounts;
                break;
            case UserSegment.Sekiyuo:
                countList = this.SekiyuoCounts;
                break;
            default:
                throw new System.ArgumentException(nameof(userSegment));
        }

        for (var i = countList.Count; i < term + 1; i++)
        {
            countList.Add(0L);
        }

        countList[term] = count;
    }
}
