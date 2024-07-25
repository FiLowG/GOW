using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vachamEXCEPTenemy: MonoBehaviour
{
    public Collider2D player;
    public Collider2D enemy;

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
        if (other is BoxCollider2D && other.gameObject.CompareTag("linhKIEM") || other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            enemy.isTrigger = true;
        }
      
    }
    public void OnTriggerExit2D(Collider2D other)
    {
      if (other is BoxCollider2D && other.gameObject.CompareTag("linhKIEM") || other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            enemy.isTrigger = false;
        }
    }
}
