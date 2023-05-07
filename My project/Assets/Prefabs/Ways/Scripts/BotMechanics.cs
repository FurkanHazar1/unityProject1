using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMechanics : MonoBehaviour
{

    public  float speed;
   


    [SerializeField] private Transform frontRt;
    [SerializeField] private Transform frontLt;
    [SerializeField] private Transform backRt;
    [SerializeField] private Transform backLt;


    private void Start()
    {
        speed = 4;
    }


    private void FixedUpdate()
    {
        
      transform.Translate(transform.forward * speed * Time.deltaTime);
      
        
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
   public void stopAnim()
    {

        frontRt.GetComponent<Animator>().enabled = false;
        frontLt.GetComponent<Animator>().enabled = false;
        backRt.GetComponent<Animator>().enabled = false;
        backLt.GetComponent<Animator>().enabled = false;
    }

}
