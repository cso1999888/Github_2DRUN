using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn_NonStatic : MonoBehaviour
{
    //靜態不需物件或元件，非靜態則需。
    public GameObject Player;

    public Transform PlayerTrans;

    public Camera cam;

    public ParticleSystem teleport;



    private void Start()
    {
        //取得
        print(Player.tag);
        print(Player.layer);
        //存放
        //PlayerTrans.position = new Vector3(0, 0, 0);
    }
    private void Update()
    {

    }


}
