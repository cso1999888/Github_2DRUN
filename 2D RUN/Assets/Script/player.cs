using UnityEngine;

public class player : MonoBehaviour
{
    #region Data type 
    //[Header("string")]
    //[Tooltip("string")]
    //[Range(float min,float max)]
    [Header("速度")]
    public float speed = 1.5f;
    [Header("血量")]
    public float HP;
    [Header("得分"), Tooltip("得分")]
    public int point;
    [Header("跳躍高度"), Range(0, 500)]
    public float JumpHeight;
    [Header("音效")]
    public AudioClip SoundJump;
    public AudioClip SoundSlide;
    public AudioClip SoundHurt;
    public AudioClip SoundPoint;
    [Header("死亡")]
    public bool dead;
    [Header("動畫控制器")]
    public Animator animator;
    public Transform PlayerTrans;
    public CapsuleCollider2D cc2d;
    public Rigidbody2D rig;
    #endregion

    #region Methods
    /// <summary>
    /// Jump: 跳躍動畫、跳躍音效、角色往上
    /// </summary>
    private void Jump()
    {
        //顛倒運算子!   !true ------- false
        bool key = Input.GetKeyDown(KeyCode.Space);
        animator.SetBool("Jump", !isGround);

        // 如果在地板上
        if (isGround)
        {
            if (key)
            {
                isGround = false; //將isGround設為false
                rig.AddForce(new Vector2(0, JumpHeight)); //施加推力
            }
        }

    }

    /// <summary>
    /// Slide: 滑行動畫、滑行音效
    /// </summary>
    private void Slide()
    {
        bool key = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Slide", key);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            cc2d.offset = new Vector2(0.002f, -0.04f);
            cc2d.size = new Vector2(0.13f, 0.13f);
        }
        else
        {
            cc2d.offset = new Vector2(0.006f, -0.025f);
            cc2d.size = new Vector2(0.15f, 0.25f);
        }
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

    private void Move()
    {
        if(rig.velocity.magnitude < 6)
            {
                //剛體添加推力
                rig.AddForce(new Vector2(speed, 0));
            }
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
        Slide();
    }
    
    /// <summary>
    /// 固定更新事件：一秒固定更新 50 次，官網建議將包含剛體之運動寫在這裡
    /// </summary>
    private void FixedUpdate()
    {
        Jump();
        Move();
    }
    /// <summary>
    /// 碰撞事件，碰到地板後執行一次
    /// </summary>
    /// <param name="collision">碰到物件的碰撞資訊</param>
    public bool isGround;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞物件名稱 = Floor
        if (collision.gameObject.name == "Floor")
        {
            isGround = true;
        }
    }
    #endregion
}
