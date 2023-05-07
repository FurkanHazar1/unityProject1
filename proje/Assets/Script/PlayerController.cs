using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float speed;
     public float turnSpeed;
     public float horizontalInput;
     public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput=Input.GetAxis("Vertical");
        horizontalInput=Input.GetAxis("Horizontal");
       // transform.Translate(0,0,1);
        transform.Translate(Vector3.forward * Time.deltaTime*speed*forwardInput);
        
        transform.Rotate(Vector3.up,Time.deltaTime*horizontalInput*turnSpeed);
    }
}
