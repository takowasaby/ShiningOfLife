using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GachaWatch : MonoBehaviour
{
    [SerializeField] Transform graphTransform;

    private bool isGraphWatch = true;
    private bool canPush = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGraph()
    {
        if (!canPush) return;

        if (isGraphWatch)
        {
            DownGraph();
        }
        else
        {
            UpGraph();
        }
    }

    public void DownGraph()
    {
        Vector3 target = graphTransform.position + new Vector3(0, -400, 0);
        
        isGraphWatch = false;
        canPush = false;

        graphTransform.DOMove(target, 1f).OnComplete(() => { canPush = true; });
    }

    public void UpGraph()
    {
        Vector3 target = graphTransform.position + new Vector3(0, 400, 0);

        isGraphWatch = true;
        canPush = false;

        graphTransform.DOMove(target, 1f).OnComplete(() => { canPush = true; });
    }

}
