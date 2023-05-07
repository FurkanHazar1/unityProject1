using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float verticalInput;
    public float verticalSpeed;
    public GameObject pizza;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<-17){
            transform.position=new Vector3(-17,transform.position.y,transform.position.z);
        }
        else if(transform.position.x>17){
            transform.position=new Vector3(17,transform.position.y,transform.position.z);
        }

        if(transform.position.z<-10){
            transform.position=new Vector3(transform.position.x,transform.position.y,-10);
        }
        else if(transform.position.z>10){
            transform.position=new Vector3(transform.position.x,transform.position.y,10);
        }
    
        
        verticalInput=Input.GetAxis("Vertical");
        horizontalInput=Input.GetAxis("Horizontal");   
        transform.Translate(Vector3.forward*Time.deltaTime*verticalInput*verticalSpeed);

        transform.Translate(Vector3.right*Time.deltaTime*horizontalInput*speed);  

         if(Input.GetKeyDown(KeyCode.Space)){
        
            Instantiate(pizza,transform.position,pizza.transform.rotation);
     }
    }
   
}
