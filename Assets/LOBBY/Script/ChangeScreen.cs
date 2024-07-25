using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ChangeScreen : MonoBehaviour
{
    public GameObject PRESENT;
    public GameObject SWITCH;
    public AudioSource ChooseSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick()
    {
        ChooseSound.Play();
        PRESENT.SetActive(false);
        SWITCH.SetActive(true);
    }
}
