using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuaDo : MonoBehaviour
{ 
    public GameObject OpenShop;
    public GameObject BuyingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        BuyingPanel.SetActive(true);
        OpenShop.SetActive(false);
    }
    public void CloseShop()
    {
        BuyingPanel.SetActive(false);
        OpenShop.SetActive(true);
    }
}
