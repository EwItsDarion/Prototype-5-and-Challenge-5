/*
		 * Darion Jeffries
		 * Target.cs
		 * Prototype 5
		 * Spawns targets to click
		 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float yRange = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;



    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //add a force upwards multiplied by speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque with a randomized x y z values
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //set the position with a randomized X value
        transform.position = RandomPos();
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        gameManager.updateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.gameActive)
        {
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
