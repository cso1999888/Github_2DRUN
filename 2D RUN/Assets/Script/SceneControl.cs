using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引用SceneManagement
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// 退出程式
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// SceneManager.LoadScene(string scene名稱) or SceneManager.LoadScene(int Scene號碼)
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene("Level");
    }

    /// <summary>
    /// invoke 延遲呼叫，用法 invoke("方法名稱", float秒數)
    /// </summary>
    public void DelayLoadScene()
    {
        Invoke("LoadScene", 0.4f);
    }
}
