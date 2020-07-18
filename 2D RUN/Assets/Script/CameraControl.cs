using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("追蹤物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 5;
    [Header("Y軸限制")]
    public Vector2 lim = new Vector2 (0, 2.9f);


    public void Track()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        b.z = -10;

        a = Vector3.Lerp(a, b, 0.8f * Time.deltaTime * speed);           //插值

        a.y = Mathf.Clamp(a.y, lim.x, lim.y);

        transform.position = a;                                          //攝影機座標 = a
    }


    //Update = 先執行
    //LateUpdate = 後執行，建議攝影機或追蹤行為
    public void LateUpdate()
    {
        Track();
    }
}

