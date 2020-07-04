using UnityEngine;

public class player : MonoBehaviour
{
    #region Data type 
    //[Header("string")]
    //[Tooltip("string")]
    //[Range(float min,float max)]
    [Header("速度"), Tooltip("血量"), Range(0, 100)]
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

    #region Methods
    /// <summary>
    /// Jump: 跳躍動畫、跳躍音效、角色往上
    /// </summary>
    private void Jump()
    {
        print("跳躍");
    }

    /// <summary>
    /// Slide: 滑行動畫、滑行音效
    /// </summary>
    private void Slide()
    {
        print("滑行");
    }

    /// <summary>
    /// Hurt: 受傷動畫、受傷音效、扣血量、更新介面（敵人消失）
    /// </summary>
    private void Hurt()
    {

    }

    /// <summary>
    /// GetPoint: 得分音效、更新得分、更新介面（草莓消失）
    /// </summary>
    private void GetPoint()
    {

    }

    /// <summary>
    /// Die: 死亡動畫、死亡音效
    /// </summary>
    private void Die()
    {

    }
    #endregion

    #region Event
    private void Start() 
    {

    }
    private void Update()
    {

    }
    #endregion
}
