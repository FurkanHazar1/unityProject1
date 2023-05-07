using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    [SerializeField] private GameObject sensor;
  
    private float destroyTime = 5f;
    [SerializeField] private GameObject way;
    [SerializeField] private GameObject SpawnWay;
    [SerializeField] private GameObject way2;
    public SpawnManeger2 spawnManeger;
    public float distance = 470;
    
    // Start is called before the first frame update
    void Start()
    {
        way = GameObject.FindGameObjectWithTag("way");
        spawnManeger = GameObject.Find("SpawnManager").GetComponent<SpawnManeger2>();

        spawnManeger.wayX = way.transform.position.x;
        spawnManeger.wayY = way.transform.position.y;
        spawnManeger.wayZ = way.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
           StartCoroutine(startBotsDestroy(other.gameObject));
            
        }
        if (other.CompareTag("endWaySensor"))
        {
           
            StartCoroutine(startWayDestroy(way));
            way = way2;
        }
        if (other.CompareTag("StartWay"))
        {
            
           way2 = Instantiate(SpawnWay, new Vector3(SpawnWay.transform.position.x,SpawnWay.transform.position.y, SpawnWay.transform.position.z + distance), SpawnWay.transform.rotation);
            distance += 470;
            Debug.Log("YAPILDI");
            
            spawnManeger.wayX = way2.transform.position.x;
            spawnManeger.wayY = way2.transform.position.y;
            spawnManeger.wayZ = way2.transform.position.z;
            
            spawnManeger.spawnBots();
        }
     
    }
    IEnumerator startBotsDestroy(GameObject other)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(other.gameObject);
    }
    IEnumerator startWayDestroy(GameObject other)
    {
        
        yield return new WaitForSeconds(destroyTime);
        Destroy(other.gameObject);

        Debug.Log("KALDIRILDI");
    }
    
}
