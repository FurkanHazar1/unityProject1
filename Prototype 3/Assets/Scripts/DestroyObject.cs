using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float gameArea=30;
    public float gameArea2=-20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z>gameArea||transform.position.z<gameArea2){
            Destroy(gameObject);
        }
    }
}
