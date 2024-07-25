using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gia3D : MonoBehaviour
{
    public GameObject linhKIEM;
    public GameObject linhSUNG;
    public GameObject Player;
    public GameObject Enemy;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("linhKIEM") ||
            other.gameObject.CompareTag("linhSUNG") ||
            other.gameObject.CompareTag("enemy"))
           
        {
            other.GetComponent<SpriteRenderer>().sortingOrder = 1001;
        }
       /* if (!other.gameObject.CompareTag("trungdanPlayer") && !other.gameObject.CompareTag("trungdanEnemy") &&
           (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("enemy") ||
           other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy") ||
           other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("linhKIEM")))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }*/

    }
    void OnTriggerExit2D(Collider2D other)
    {
            linhKIEM.GetComponent<SpriteRenderer>().sortingOrder = 1001;
            linhSUNG.GetComponent<SpriteRenderer>().sortingOrder = 1001;
            Player.GetComponent<SpriteRenderer>().sortingOrder = 100;
            Enemy.GetComponent<SpriteRenderer>().sortingOrder = 100;
            bullet.GetComponent<SpriteRenderer>().sortingOrder = 1001;
       /* if (!other.gameObject.CompareTag("trungdanPlayer") && !other.gameObject.CompareTag("trungdanEnemy") &&
               (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("enemy") ||
               other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy") ||
               other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("linhKIEM")))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }*/

    }
}
