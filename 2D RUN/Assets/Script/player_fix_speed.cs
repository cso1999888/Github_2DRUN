using UnityEngine;
using UnityEngine.UI;

public class player_fix_speed : MonoBehaviour
{
    #region Data type 
    //[Header("string")]
    //[Tooltip("string")]
    //[Range(float min,float max)]
    [Header("速度")]
    public float speed = 0.1f;
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
    public Text textPoint;
    public Image HPBar;
    private float HPMax;
    public AudioSource aud;
    public GameObject fin;
    public Text TextPoint;
    public Text TextFin;
    #endregion

    #region Methods
    /// <summary>
    /// Jump: 跳躍動畫、跳躍音效、角色往上
    /// </summary>
    private void Jump()
    {
        //顛倒運算子!   !true ------- false
        bool key = Input.GetKey(KeyCode.Space);
        animator.SetBool("Jump", !isGround);

        // 如果在地板上
        if (isGround)
        {
            if (key)
            {
                isGround = false; //將isGround設為false
                rig.AddForce(new Vector2(0, JumpHeight)); //施加推力
                aud.PlayOneShot(SoundJump);
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

        //只有單行程式碼時可省略大括號
        if(Input.GetKeyDown(KeyCode.LeftControl)) aud.PlayOneShot(SoundSlide, 0.5f);

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
    private void Hurt(Collider2D collision)
    {
        HP -= 50;
        Destroy(collision.gameObject);  // 摧毀碰撞物件
        HPBar.fillAmount = HP / HPMax;  // 圖片填滿程度 = HP / HPMax
        aud.PlayOneShot(SoundHurt);     // 播放音效一次

        if (HP <= 0) Die();             // HP小於0死亡
    }

    /// <summary>
    /// 整理吃金幣程式碼   得分音效、更新得分、更新介面（草莓消失）
    /// </summary>
    /// <param name="collision"></param>
    private void Point(Collider2D collision)
    {
        point++;
        Destroy(collision.gameObject);
        textPoint.text = "Point: " + point;
        aud.PlayOneShot(SoundPoint);
    }

    private void Move()
    {
        PlayerTrans.Translate(speed, 0, 0);
    }

    /// <summary>
    /// Die: 死亡動畫、死亡音效
    /// </summary>
    private void Die()
    {
        if (dead) return;              // 如果死亡，跳出迴圈

        speed = 0;
        dead = true;
        animator.SetTrigger("Die");    // 播放死亡動畫
        fin.SetActive(true);           // 顯示結束畫面
        TextPoint.text = "Point: " + point;
        TextFin.text = "Game Over";
    }

    private void Win()
    {
        fin.SetActive(true);
        TextPoint.text = "Point: " + textPoint;
        TextFin.text = "Win!";
        speed = 0;
    }
    #endregion

    #region Event
    private void Start()
    {
        HPMax = HP; //最大值 = 初始值
    }
    private void Update()
    {
        if (dead) return;

        Slide();
        if (transform.position.y <= -5) Die();
    }
    
    /// <summary>
    /// 固定更新事件：一秒固定更新 50 次，官網建議將包含剛體之運動寫在這裡
    /// </summary>
    private void FixedUpdate()
    {
        if (dead) return;

        Jump();
        Move();
    }
    /// <summary>
    /// 碰撞事件，碰到地板後執行一次
    /// </summary>
    /// <param name="collision">碰到物件的碰撞資訊</param>
    public bool isGround;

    /// <summary>
    /// 碰撞物件
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞物件名稱 = Floor
        if (collision.gameObject.name == "Floor")
        {
            isGround = true;
        }

        //如果碰撞物件名稱 = Floor
        if (collision.gameObject.name == "Floats")
        {
            isGround = true;
        }
    }
    
    /// <summary>
    /// 觸發物件
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果觸發物件tag = Point
        if (collision.tag == "Point") Point(collision);
        if (collision.tag == "Enemy") Hurt(collision);
        if (collision.name == "Teleport") Win();

    }
    #endregion
}

