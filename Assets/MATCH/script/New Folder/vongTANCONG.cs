using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vongTANCONG : MonoBehaviour
{
    public GameObject zoneattack;

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
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            zoneattack.SetActive(true);
        }
      
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("linhKiemEnemy") || other.gameObject.CompareTag("linhSungEnemy"))
        {
            zoneattack.SetActive(false);
        }
    }
}