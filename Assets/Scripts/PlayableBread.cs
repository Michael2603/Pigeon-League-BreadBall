using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableBread : MonoBehaviour
{
    Rigidbody2D rigidBody2d;
    public int keyPressTotal;
    public int keyPressCounter;

    public float maxSpeed;
    public float speedCounter;

    public float bonusSpeed;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        speedCounter = maxSpeed;
    }

    void Update()
    {
        rigidBody2d.velocity = new Vector3(speedCounter, 0,0);
        if (speedCounter > 0)
            speedCounter -= Time.deltaTime * .9f;

        if (Input.GetKeyDown(KeyCode.W))
        {
            keyPressCounter++;
            if (speedCounter < maxSpeed)
                speedCounter += bonusSpeed;
        }

        if (speedCounter >= maxSpeed * .92f)
            GetComponent<ParticleSystem>().Play();
        else if (speedCounter < maxSpeed * .92f)
            GetComponent<ParticleSystem>().Stop();
    }
}