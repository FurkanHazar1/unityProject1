using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float throttleIncrease=0.1f;
    public float maxThrust = 200f;
    public float responsivenes = 100f;

    [SerializeField] private Transform propella;

    [SerializeField] private GameObject gearL;
    [SerializeField] private GameObject gearR;

  
   
 


    [SerializeField] private WheelCollider gearLcol;
    [SerializeField] private WheelCollider gearRcol;
    [SerializeField] private WheelCollider gearBcol;
    [SerializeField] private float openGearSpeed;
   
    private float throttle;
    private float pitch;
    private float yaw;
    private float roll;


    private bool isOnGround=false;
    public bool isGearOpened = false;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        handleInputs();
        
        propella.transform.Rotate(Vector3.up * throttle);

        if (Input.GetKeyDown(KeyCode.G))
        {

            openGear();
        }

            if (gameObject.transform.position.y == 0) isOnGround = true;
    }

    private void FixedUpdate()
    {
        forceControll();
        
        

    }


    private void handleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrease;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrease;

        throttle = Mathf.Clamp(throttle,0, 100);

    }

    private void forceControll()
    {

        

       

        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsivenes);
        rb.AddTorque(transform.right * pitch* responsivenes);
        rb.AddTorque(transform.forward * -roll* responsivenes);


    }



    private void openGear()
    {
        if (isGearOpened == true)
        {
            isGearOpened = false;
            gearLcol.gameObject.SetActive(false);
            gearRcol.gameObject.SetActive(false);
            gearL.transform.rotation = Quaternion.Lerp(gearL.transform.rotation, Quaternion.Euler(-90, -90, 90), openGearSpeed * Time.deltaTime);
             gearR.transform.rotation = Quaternion.Lerp(gearR.transform.rotation, Quaternion.Euler(-90, -90, 90), openGearSpeed * Time.deltaTime);
            return;
        }

        isGearOpened = true;

        gearL.transform.rotation = Quaternion.Lerp(gearL.transform.rotation,Quaternion.Euler(-180,-90,90),1);
        gearR.transform.rotation = Quaternion.Lerp(gearR.transform.rotation, Quaternion.Euler(0,-90,90),1);
      
        
        gearLcol.gameObject.SetActive(true);
        gearRcol.gameObject.SetActive(true);
        

    }
    private void gearControl()
    {
        

    }
    private float Res()
    {
        return (rb.mass / 10) * responsivenes;
    }


}
