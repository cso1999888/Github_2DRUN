using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn_if : MonoBehaviour
{
    //
    public bool test;
    public bool openDoor;
    // Start is called before the first frame update
    void Start()
    {
        //Bool = ture 時才執行內容。
        if (test)
        {
            print("if");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Bool = true 時執行if
        //Bool = false 時執行else
        if (openDoor)
        {
            print("Door opened");
        }
        else
        {
            print("Door Closed");
        }
    }
}
