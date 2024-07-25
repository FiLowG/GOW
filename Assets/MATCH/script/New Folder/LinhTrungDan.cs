using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class LinhTrungDan : MonoBehaviour
{
    public GameObject owner;
    public GameObject trungdan;
    public Image healLinhPlayer;
    public Image healLinhEnemy;
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
        if(other.gameObject.CompareTag("bulletPlayer"))
            {
            if (!owner.IsDestroyed())
            {
                healLinhEnemy.fillAmount -= 0.1f;
                if (healLinhEnemy.fillAmount == 0)
                {
                    Destroy(owner);
                }
            }
          }
        if (other.gameObject.CompareTag("bulletEnemy"))
        {
            if (!owner.IsDestroyed())
            {
                healLinhPlayer.fillAmount -= 0.1f;
                if (healLinhPlayer.fillAmount == 0)
                {
                    Destroy(owner);
                }
            }
        }
    }
}
