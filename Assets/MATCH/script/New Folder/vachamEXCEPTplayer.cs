using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vachamEXCEPTplayer : MonoBehaviour
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
        if (other.gameObject.CompareTag("linhKIEM") || other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            player.isTrigger = true;
        }
      

    }
    public void OnTriggerExit2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("linhKIEM") || other.gameObject.CompareTag("linhSUNG") || other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            player.isTrigger = false;
        }

    }
}
