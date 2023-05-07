using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pervane : MonoBehaviour
{
    public  GameObject don;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        don=GameObject.Find("Propeller");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation=new Vector3(0,0,speed);
        don.transform.Rotate(rotation);
    }
}
