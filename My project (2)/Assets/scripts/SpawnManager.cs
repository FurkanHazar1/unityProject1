using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject preFabs;
    public float firstStart=2;
    public float repeat = 2;
    public Vector3 range=new Vector3(30,0,0);
    private PlayerController stop;
    
    // Start is called before the first frame update
    void Start()
    {
        stop = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnPreFab",firstStart,repeat);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void spawnPreFab(){
        if (stop.gameOver == false)
        {
            Instantiate(preFabs, range, preFabs.transform.rotation);
        }
    }
}