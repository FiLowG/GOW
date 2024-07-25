using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnLINH : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public Transform spawnLocation;
    public Transform spawnLocation2;
    public float speedlinh = 200f;

    public List<GameObject> group1 = new List<GameObject>();  // Make it public if you want to access directly
    private List<GameObject> group2 = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnSequence());
        StartCoroutine(SpawnSequence2());
    }
 
    IEnumerator SpawnSequence()
    {
        yield return new WaitForSeconds(5);

        // Spawn prefab "1" lần đầu tiên
        GameObject instance1 = Instantiate(prefab1, spawnLocation.position, spawnLocation.rotation);
        instance1.tag = "KIEMprefabs";
        group1.Add(instance1);
        SetInitialVelocity(instance1, group2.Count > 0 ? group2[0] : null);

        yield return new WaitForSeconds(0.7f);  // Chờ 2 giây

        // Spawn prefab "1" lần thứ hai
        GameObject instance2 = Instantiate(prefab1, spawnLocation.position, spawnLocation.rotation);
        instance2.tag = "KIEMprefabs";
        group1.Add(instance2);
        SetInitialVelocity(instance2, group2.Count > 1 ? group2[1] : null);

        yield return new WaitForSeconds(0.7f);  // Chờ 2 giây

        // Spawn prefab "2"
        GameObject instance3 = Instantiate(prefab2, spawnLocation.position, spawnLocation.rotation);
        instance3.tag = "SUNGprefabs";
        group1.Add(instance3);
        SetInitialVelocity(instance3, group2.Count > 2 ? group2[2] : null);
        yield return new WaitForSeconds(30);
        CallAfter30seconds1();
    }

    IEnumerator SpawnSequence2()
    {
        yield return new WaitForSeconds(5);

        // Spawn prefab "3" lần đầu tiên
        GameObject instance1 = Instantiate(prefab3, spawnLocation2.position, spawnLocation2.rotation);
        group2.Add(instance1);
        SetInitialVelocity(instance1, group1.Count > 0 ? group1[0] : null);

        yield return new WaitForSeconds(0.7f);  // Chờ 2 giây

        // Spawn prefab "3" lần thứ hai
        GameObject instance2 = Instantiate(prefab3, spawnLocation2.position, spawnLocation2.rotation);
        group2.Add(instance2);
        SetInitialVelocity(instance2, group1.Count > 1 ? group1[1] : null);

        yield return new WaitForSeconds(0.7f);  // Chờ 2 giây

        // Spawn prefab "4"
        GameObject instance3 = Instantiate(prefab4, spawnLocation2.position, spawnLocation2.rotation);
        group2.Add(instance3);
        SetInitialVelocity(instance3, group1.Count > 2 ? group1[2] : null);
        yield return new WaitForSeconds(30);
        CallAfter30seconds2();
    }

    void SetInitialVelocity(GameObject instance, GameObject target)
    {
        if (instance == null || target == null) return;

        Vector2 direction = (target.transform.position - instance.transform.position).normalized;
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * speedlinh * Time.deltaTime;
        }
    }

    void Update()
    {
        for (int i = 0; i < Mathf.Min(group1.Count, group2.Count); i++)
        {
            MoveTowardsEachOther(group1[i], group2[i]);
        }
    }

    void MoveTowardsEachOther(GameObject from, GameObject to)
    {
        if (from == null || to == null) return;

        Vector2 directionFromTo = (to.transform.position - from.transform.position).normalized;
        Vector2 directionToFrom = (from.transform.position - to.transform.position).normalized;

        Rigidbody2D rbFrom = from.GetComponent<Rigidbody2D>();
        Rigidbody2D rbTo = to.GetComponent<Rigidbody2D>();

        if (rbFrom != null)
        {
            rbFrom.velocity = directionFromTo * speedlinh * Time.deltaTime;
        }

        if (rbTo != null)
        {
            rbTo.velocity = directionToFrom * speedlinh * Time.deltaTime;
        }
    }
    public void CallAfter30seconds1()
    {
        StartCoroutine(SpawnSequence());
       
    }
    public void CallAfter30seconds2()
    {
        StartCoroutine(SpawnSequence2());

    }
}
