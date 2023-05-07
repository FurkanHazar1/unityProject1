using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMechanics : MonoBehaviour
{
  [SerializeField] private WheelCollider FrontRightCol;
  [SerializeField] private WheelCollider FrontLeftCol;
  [SerializeField] private WheelCollider BackRightCol;
  [SerializeField] private WheelCollider BackLeftCol;
                  
  [SerializeField] private Transform FrontRight;
  [SerializeField] private Transform FrontLeft;
  [SerializeField] private Transform BackRight;
  [SerializeField] private Transform BackLeft;
                
  [SerializeField] private float EnginePower;
  [SerializeField] private float BreakeForce;
  [SerializeField] private float maxSteeringAngel;




    public GameObject RBarcol;
    public GameObject LBarcol;
    public bool isCollison;
    
   
    public Rigidbody rb;
    public float topSpeed = 180;
    private float horizontalInput;
    private float verticalInput;
    private bool isBreake;
    public float Speed;
    private float currentSteerAngle;
    private float currentBreakForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isCollison = false;
    }
    private void FixedUpdate()
    {
        
        GetInput();

       Speed = FindSpeed();
       handleEngine();
 
        handleSteering();
        updateWheels();
       
        
    }
    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreake = Input.GetKey(KeyCode.Space);
    }
    void handleEngine()
    {
        
        FrontRightCol.motorTorque = EnginePower;
        FrontLeftCol.motorTorque = EnginePower;
        currentBreakForce = isBreake ? BreakeForce : 0f;
        applyBreaking();
    }
    void handleSteering()
    {
        currentSteerAngle = maxSteeringAngel * horizontalInput;
        FrontLeftCol.steerAngle = currentSteerAngle;
        FrontRightCol.steerAngle = currentSteerAngle;
    }
    void updateWheels()
    {
        updateSingleWheels(FrontLeftCol, FrontLeft);
        updateSingleWheels(FrontRightCol, FrontRight);
        updateSingleWheels(BackLeftCol, BackLeft);
        updateSingleWheels(BackRightCol, BackRight);
    }
    void updateSingleWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
     
       wheelTransform.transform.rotation = rot;

        wheelTransform.transform.position = pos;
    }
    void applyBreaking()
    {
        FrontLeftCol.brakeTorque = currentBreakForce;
        FrontRightCol.brakeTorque = currentBreakForce;
        BackLeftCol.brakeTorque = currentBreakForce;
        BackRightCol.brakeTorque = currentBreakForce;
    }
    public float FindSpeed()
    {
        float speed = rb.velocity.magnitude;
        speed *=1.8f;
        if (speed > topSpeed)
        {
            rb.velocity = (topSpeed / 1.8f) * rb.velocity.normalized;
        }
        if (isCollison)
        {
            rb.velocity = rb.velocity.normalized * 0;
        }
        
        return speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isCollison = true;
       
    }
}
