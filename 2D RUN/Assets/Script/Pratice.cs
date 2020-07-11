using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pratice : MonoBehaviour
{
    #region Method
    //定義方法：修飾詞 傳回類型 方法名稱 (傳回內容) {程式碼}。Test無法用作方法名稱，因其與 unity 既有方法名稱衝突。
    public void Test123()
    {
        print("Test123");
    }

    // 傳回內容 = string s = 傳回字串 s, i.g., Skill("fire") → s = fire, print("施放技能" + s) = print("施放技能" + fire)
    public void Skill(string s)
    {
        print("施放技能" + s);
    }
    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        print("press space to get random number (100-500)");
    }

    // Update is called once per frame
    public void Update()
    {

        //取得 100 - 500 的隨機值
        if (Input.GetKeyDown("space"))
        {
            print(Random.Range(100, 501));
            //(min is inclusive, while max is exclusive)
            Test123();
            Skill("fire");
            Skill("ice");
        }
    }

}
