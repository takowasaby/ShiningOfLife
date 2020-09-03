using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow2D : MonoBehaviour
{
    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;
    [SerializeField] private float distance = 1f;

    Vector3 defaultPos;
    private void Start()
    {
        defaultPos = transform.localPosition;
    }

    private void Update()
    {
        // マウス位置をスクリーン座標からワールド座標に変換する
        var targetPos = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        
        // Z座標を修正する
        targetPos.z = 0f;

        //transform.position = defaultPos + (transform.position - targetPos).normalized * distance;
        transform.localPosition = Vector3.Lerp(transform.localPosition, defaultPos + (targetPos-transform.localPosition).normalized * distance, followStrength);
    }
}
