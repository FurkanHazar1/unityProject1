using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float forwardSpeed = 10f;
    public GameObject focusPoint;
    public bool hasPowerUp = false;
    public float powerUpStreng = 15;
    public GameObject powerUpicon;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focusPoint = GameObject.Find("FocusPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focusPoint.transform.forward * forwardInput* forwardSpeed);
        powerUpicon.transform.position = playerRb.transform.position + new Vector3(0, -0.39f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            powerUpicon.gameObject.SetActive(true);
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountDown());
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDistance = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(forceDistance * powerUpStreng, ForceMode.Impulse);
            Debug.Log("powerUp ile carpisma oldu");
        }
    }

    IEnumerator powerUpCountDown()
    {
        yield return new WaitForSeconds(3);
        hasPowerUp = false;
        powerUpicon.gameObject.SetActive(false);
    }
}
