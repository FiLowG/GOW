using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GETDAME : MonoBehaviour
{
    public Image healPlayer;
    public Image healEnemy;
    public GameObject getDameplayer;
    public GameObject getDameenemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (getDameplayer.activeSelf)
        {
            
            healPlayer.fillAmount -= 0.1f;
            getDameplayer.SetActive(false);
        }
        
        if (getDameenemy.activeSelf)
        {
            healEnemy.fillAmount -= 0.1f;
            getDameenemy.SetActive(false);
        }
    }
}
