using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PlayerP;
    private Animator playerAnim;
    public float jumpForce;
    public float gravityMovement;
    public bool isOnGround=true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
           PlayerP= GetComponent<Rigidbody>();
           playerAnim = GetComponent<Animator>();
            Physics.gravity*=gravityMovement;           
    }

    // Update is called once per frame
    void Update()
    {
        
          if(Input.GetKeyDown(KeyCode.Space)&&isOnGround==true){
            isOnGround=false;
            
            PlayerP.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Engel"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
