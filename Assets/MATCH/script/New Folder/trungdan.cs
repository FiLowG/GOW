using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trungdan : MonoBehaviour
{
    public GameObject owner;
    public GameObject getDameplayer;
    public GameObject getDameenemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (owner.gameObject.CompareTag("trungdanPlayer"))
        {
            if (other.gameObject.CompareTag("bulletEnemy"))
            {
                Destroy(other.gameObject);
                getDameplayer.SetActive(true);
            }

          
        }
        if (owner.gameObject.CompareTag("trungdanEnemy"))
        {
            if (other.gameObject.CompareTag("bulletPlayer"))
            {
                Destroy(other.gameObject);
                getDameenemy.SetActive(true);
            }
           
        }
        if (owner.gameObject.CompareTag("trungdanKIEMPlayer"))
        {
            if (other.gameObject.CompareTag("bulletEnemy"))
            {
                Destroy(other.gameObject);
               
            }
        }
        if (owner.gameObject.CompareTag("trungdanSUNGPlayer"))
        {
            if (other.gameObject.CompareTag("bulletEnemy"))
            {
                Destroy(other.gameObject);

            }

        }
        if (owner.gameObject.CompareTag("trungdanKIEMEnemy"))
        {
            if (other.gameObject.CompareTag("bulletPlayer"))
            {
                Destroy(other.gameObject);

            }
        }
        if (owner.gameObject.CompareTag("trungdanSUNGEnemy"))
        {
            if (other.gameObject.CompareTag("bulletPlayer"))
            {
                Destroy(other.gameObject);

            }
        }
    }
}
