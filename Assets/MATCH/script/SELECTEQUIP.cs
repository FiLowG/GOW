using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SELECTEQUIP : MonoBehaviour
{
    public GameObject EquipSelect;
    public GameObject SubPanel;
    public Image EquipICON;
    public Text EquipmentName;
    public Text Price;
    public Text Describe;
    public Text Lore;
    public Image SLOT1;
    public Image SLOT2;
    public Image SLOT3;
    public Image SLOT4;
    public Image SLOT5;
    public Image SLOT6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectEquip()
    {
        SubPanel.SetActive(true);
        EquipmentName.text = EquipSelect.name;
        Describe.text = EquipSelect.GetComponent<Text>().text;
        Lore.text = EquipSelect.GetComponent<TextMesh>().text;
        if (EquipSelect.CompareTag("EQUIPLV1"))
        {
            Price.text = "220";
        }
        else if (EquipSelect.CompareTag("EQUIPLV2"))
        {
            Price.text = "500";
        }
        else if (EquipSelect.CompareTag("EQUIPLV3"))
        {
            Price.text = "1000";
        }
        else
        {
            Price.text = "100";
        }

        
    }

   public void AssignToSlot(Image equipIcon)
    {
        /*equipIcon = EquipICON;*/
        if (SLOT1.sprite == null)
        {
            SLOT1.sprite = equipIcon.sprite;
            SLOT1.color = new Color32(255, 255, 255, 255);
            SLOT1.enabled = true;
            if (SLOT1.sprite == null)
            {
                SLOT1.color = new Color32(0, 0, 28, 255);
            }
        }
        else if (SLOT2.sprite == null)
        {
            SLOT2.sprite = equipIcon.sprite;
            SLOT2.enabled = true;
            if (SLOT2.sprite == null)
            {
                SLOT2.color = new Color32(0, 0, 28, 255);
            }

        }
        else if (SLOT3.sprite == null)
        {
            SLOT3.sprite = equipIcon.sprite;
            SLOT3.enabled = true;
            if (SLOT3.sprite == null)
            {
                SLOT3.color = new Color32(0, 0, 28, 255);
            }
        }
        else if (SLOT4.sprite == null)
        {
            SLOT4.sprite = equipIcon.sprite;
            SLOT4.enabled = true;
            if (SLOT4.sprite == null)
            {
                SLOT4.color = new Color32(0, 0, 28, 255);
            }
        }
        else if (SLOT5.sprite == null)
        {
            SLOT5.sprite = equipIcon.sprite;
            SLOT5.enabled = true;
            if (SLOT5.sprite == null)
            {
                SLOT5.color = new Color32(0, 0, 28, 255);
            }
        }
        else if (SLOT6.sprite == null)
        {
            SLOT6.sprite = equipIcon.sprite;
            SLOT6.enabled = true;
            if (SLOT6.sprite == null)
            {
                SLOT6.color = new Color32(0, 0, 28, 255);
            }
        }
    }
}
