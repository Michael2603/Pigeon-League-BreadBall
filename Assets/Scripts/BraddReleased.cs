using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraddReleased : MonoBehaviour
{
    bool startTransition = false;
    
    float transitionTimer = 2;

    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (startTransition)
        {
            transitionTimer -= Time.deltaTime;

            rigidbody2d.velocity = new Vector3(rigidbody2d.velocity.x - Time.deltaTime * Mathf.Sign(rigidbody2d.velocity.x) * 1.5f, rigidbody2d.velocity.y - Time.deltaTime * Mathf.Sign(rigidbody2d.velocity.y) * 1.5f, 0);
            if (transitionTimer <= 0)
                GameObject.Find("MajorController").GetComponent<MajorController>().TransitionRunner();
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "Receptor")
        {
            startTransition = true;
        }
    }
}
