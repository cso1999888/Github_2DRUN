using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn_Lerp : MonoBehaviour
{
    public int a;
    public int b;
    public float c = 0;
    public float d = 100;
    public Vector2 va = new Vector2 (0, 0);
    public Vector2 vb = new Vector2(100, 100);
    public Color ca = new Color(1, 0, 0);
    public Color cb = new Color(1, 0, 1);


    // Start is called before the first frame update
    void Start()
    {
        float r = Mathf.Lerp(a, b, 0.7f);
        print(r);
    }

    // Update is called once per frame
    void Update()
    {
        c = Mathf.Lerp(c, d, 0.5f * Time.deltaTime);
        va = Vector2.Lerp(va, vb, 0.5f * Time.deltaTime);
        ca = Color.Lerp(ca, cb, 0.5f * Time.deltaTime);
    }
}
