/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAP : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng không có tag "trungdan"
        if (!other.gameObject.CompareTag("trungdanPlayer") && !other.gameObject.CompareTag("trungdanEnemy") &&
            (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("enemy") ||
            other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy") ||
            other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("linhKIEM")))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng không có tag "trungdan"
        if (!other.gameObject.CompareTag("trungdanPlayer") && !other.gameObject.CompareTag("trungdanEnemy") &&
            (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("enemy") ||
            other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy") ||
            other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("linhKIEM")))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
*/