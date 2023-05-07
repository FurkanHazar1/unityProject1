using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnimalArray : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float range1=-17;
    public float range2=17; 
    public float firstStart=2;
    public float repeat=1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnAnimal",firstStart,repeat);
    }

    // Update is called once per frame
    void Update()
    {
      
     
    }
    void spawnAnimal(){
            float range=Random.Range(range1,range2);
            int animalIndex=Random.Range(0,animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex],new Vector3(range,0,20),animalPrefabs[animalIndex].transform.rotation);
          

    }
}
