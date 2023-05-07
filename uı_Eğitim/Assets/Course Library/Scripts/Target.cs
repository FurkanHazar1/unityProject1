using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody targetRb;
    public GameManager gameManager;
    private int minSpeed = 12;
    private int maxSpedd = 16;
    private int maxTorque = 10;
    private int xRange = 4;
    private int yRange = -2;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.position = randomPosition();
        targetRb.AddForce(randomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.updateScore(pointValue);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.StartGameOver();
        }
      
    }
    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpedd);
    }

    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }
}
