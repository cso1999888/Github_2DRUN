using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("press space to get random number (100-500)");
    }

    // Update is called once per frame
    void Update()
    {
        //取得 100 - 500 的隨機值
        if (Input.GetKeyDown("space"))
        {
            print(Random.Range(100, 501));
            //(min is inclusive, while max is exclusive)
        }
    }
}
