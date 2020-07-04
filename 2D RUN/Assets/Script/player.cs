using UnityEngine;

public class player : MonoBehaviour
{
    //[Header("string")]
    //[Tooltip("string")]
    //[Range(float min,float max)]
    #region Data type 
    [Header("速度"),Tooltip("血量"),Range(0,100)]
    public float speed = 1f;
    [Header("血量")]
    public float HP;
    [Header("得分"), Tooltip("得分")]
    public int point;
    [Header("跳躍高度")]
    public float JumpHeight;
    [Header("音效")]
    public AudioClip SoundJump;
    public AudioClip SoundSlide;
    public AudioClip SoundHurt;
    public AudioClip SoundPoint;
    [Header("死亡")]
    public bool dead;
    #endregion
}
