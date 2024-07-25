using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private GameObject linhSUNG;
    private GameObject linhKIEM;
    public GameObject kiemPrefab;
    public float speedAttack = 20;
    public GameObject bulletSHOT;
    private GameObject kiemprefabs;
    private GameObject target;
    public bool Exist = false;
    public GameObject EnMAttack;
    private float attackCooldown = 1.5f; // Thời gian giãn cách giữa các cuộc tấn công
    private float lastAttackTime; // Thời điểm cuối cùng tấn công


    public void OnTriggerStay2D(Collider2D other)
    {
        // Ưu tiên cao nhất là Player
        if (other.CompareTag("Player"))
        {
            target = player;
            EnMAttack.SetActive(true);
        }
        // Ưu tiên thứ hai là linhKIEM, chỉ cập nhật target nếu hiện tại không phải là Player
        else if (other.CompareTag("KIEMprefabs") && (target == null || !target.CompareTag("Player")))
        {
            linhKIEM = other.gameObject;
            target = linhKIEM;
            EnMAttack.SetActive(true);
        }
        // Ưu tiên thứ ba là linhSUNG, chỉ cập nhật target nếu hiện tại không phải là Player hoặc linhKIEM
        else if (other.CompareTag("SUNGprefabs") && (target == null || (!target.CompareTag("Player") && !target.CompareTag("KIEMprefabs"))))
        {   
            linhSUNG = other.gameObject;
            target = linhSUNG;
            EnMAttack.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Khi đối tượng rời khỏi trigger, kiểm tra nếu đó là target hiện tại thì xóa và tắt EnMAttack
        if (target == other.gameObject)
        {
            target = null;
            EnMAttack.SetActive(false);
        }
    }
    void Update()
    {
        if (target != null)
        {
            Debug.Log(target.name);
        }
        if (kiemprefabs == null)
        {
            Exist = false;
        }
        if (kiemprefabs != null)
        {
            Exist = true;
        }
        if (EnMAttack.activeSelf && Time.time - lastAttackTime > attackCooldown)
        {
            StartCoroutine(SpawnAndAimKiemAtEnemy());
            lastAttackTime = Time.time; // Cập nhật thời điểm tấn công cuối cùng
        }

    }

    IEnumerator SpawnAndAimKiemAtEnemy()
    {
        if (!Exist)
        {

            yield return null;

            // Tạo prefabs của kiếm tại vị trí của bulletSHOT
            kiemprefabs = Instantiate(kiemPrefab, bulletSHOT.transform.position, Quaternion.identity);
            Rigidbody2D kiemRigidbody = kiemprefabs.GetComponent<Rigidbody2D>();

            // Tính toán hướng để kiếm bay về phía player
            Vector2 directionToEnemy = (target.transform.position - kiemprefabs.transform.position).normalized;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            kiemprefabs.transform.rotation = rotation;

            // Thiết lập vận tốc cho kiếm dựa trên hướng
            kiemRigidbody.velocity = directionToEnemy * speedAttack;

            StartCoroutine(DestroyBullet());
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(kiemprefabs.gameObject);
    }
}