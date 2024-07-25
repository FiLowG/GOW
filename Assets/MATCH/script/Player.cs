using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5;
    private Animator RUNanimation;
    public GameObject enemy;
    public GameObject kiem;
    public float speedattack = 5;
    public GameObject bulletSHOT;
    public GameObject bulletSHOTLEFT;
    public GameObject bulletSHOTRIGHT;
    private GameObject kiemprefabs;
    public GameObject vongTANCONG;
    public GameObject zoneattack;
    private Vector2 attackDirection;
    private float attackAngle;
    private bool canMove = true;
    private bool isAttacking = false; // Biến kiểm tra trạng thái tấn công
    public bool allowattack = true;

    void Start()
    {
        attackDirection = Vector2.right;
        rb = GetComponent<Rigidbody2D>();
        RUNanimation = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            // Di chuyển nhân vật.
            float hrz = Input.GetAxisRaw("Horizontal");
            float vrt = Input.GetAxisRaw("Vertical");
            bool isMoving = Mathf.Abs(hrz) > .1f || Mathf.Abs(vrt) > .1f;

            if (isMoving)
            {
                rb.velocity = new Vector2(hrz * speed, vrt * speed);
                if (!RUNanimation.GetCurrentAnimatorStateInfo(0).IsName("PhapSuRUN"))
                {
                    RUNanimation.Play("PhapSuRUN");
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
                if (RUNanimation.GetCurrentAnimatorStateInfo(0).IsName("PhapSuRUN"))
                {
                    RUNanimation.Play("PhapSuIDLE");
                }
            }

            // Xác định hướng tấn công dựa trên giá trị GetAxisRaw
            if (hrz == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false; // Không lật khi di chuyển sang phải
                attackDirection = Vector2.right;
                attackAngle = 0;
                bulletSHOT = bulletSHOTRIGHT;
            }
            else if (hrz == -1)
            {
                GetComponent<SpriteRenderer>().flipX = true; // Lật khi di chuyển sang trái
                attackDirection = Vector2.left;
                attackAngle = 180;
                bulletSHOT = bulletSHOTLEFT;
            }
            else if (vrt == 1)
            {
                attackDirection = Vector2.up;
                attackAngle = 90;
            }
            else if (vrt == -1)
            {
                attackDirection = Vector2.down;
                attackAngle = -90;
            }
        }

        // Gọi tấn công và bật tắt vùng tấn công.
        bool attack = Input.GetKeyDown(KeyCode.F);
        bool unattack = Input.GetKeyUp(KeyCode.F);
        if (attack && !isAttacking && allowattack) // Chỉ cho phép tấn công nếu không đang tấn công và được phép tấn công
        {
            vongTANCONG.SetActive(true);
            StartCoroutine(TanCong());
        }

        if (unattack)
        {
            vongTANCONG.SetActive(false);
        }
    }

    IEnumerator AllowsAttack()
    {
        allowattack = false;
        yield return new WaitForSeconds(0.4f);
        allowattack = true;
    }

    IEnumerator TanCong()
    {
        isAttacking = true; // Đánh dấu bắt đầu tấn công
        canMove = false;
        rb.velocity = Vector2.zero;
        RUNanimation.Play("PhapSuATTACK");

        if (zoneattack.activeSelf)
        {
            StartCoroutine(SpawnAndAimKiemAtEnemy());
        }
        else
        {
            StartCoroutine(SpawnAndShootKiemStraight());
        }

        yield return new WaitForSeconds(0.4f);

        canMove = true;
        isAttacking = false; // Đánh dấu kết thúc tấn công
        RUNanimation.Play("PhapSuIDLE");
        StartCoroutine(AllowsAttack());
    }

    #region Hàm Destroy đạn.
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        if (kiemprefabs != null)
        {
            Destroy(kiemprefabs.gameObject);
        }
    }
    #endregion

    #region Hàm bắn mục tiêu theo mục tiêu.
    IEnumerator SpawnAndAimKiemAtEnemy()
    {
     
        yield return new WaitForSeconds(0.2f);

        // Tạo prefabs của kiếm tại vị trí của bulletSHOT
        kiemprefabs = Instantiate(kiem, bulletSHOT.transform.position, Quaternion.identity);
        Rigidbody2D kiemRigidbody = kiemprefabs.GetComponent<Rigidbody2D>();

        // Tính toán hướng để kiếm bay về phía enemy
        Vector2 directionToEnemy = (enemy.transform.position - kiemprefabs.transform.position).normalized;

        // Tính góc giữa hướng hiện tại của kiếm và hướng tới enemy
        float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        kiemprefabs.transform.rotation = rotation;

        // Thiết lập vận tốc cho kiếm dựa trên hướng
        kiemRigidbody.velocity = directionToEnemy * speedattack * 2;

        StartCoroutine(DestroyBullet());
        yield return new WaitForSeconds(0.1f);
    }
    #endregion

    #region Hàm bắn thẳng.
    IEnumerator SpawnAndShootKiemStraight()
    {
        yield return new WaitForSeconds(0.2f);

        kiemprefabs = Instantiate(kiem, bulletSHOT.transform.position, Quaternion.Euler(0, 0, attackAngle));
        kiemprefabs.GetComponent<Rigidbody2D>().velocity = attackDirection * speedattack;
       

        StartCoroutine(DestroyBullet());
        yield return new WaitForSeconds(0.1f);
    }
    #endregion
}
