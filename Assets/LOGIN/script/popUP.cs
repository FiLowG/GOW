using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUP : MonoBehaviour
{
    public GameObject pop;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(popup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator popup()
    {
        yield return new WaitForSeconds(2f);
        pop.SetActive(true);
    }
}
