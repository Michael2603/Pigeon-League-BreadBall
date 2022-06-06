using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePivot : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float flappingDistance;
    public float flappingMoveSpeed;
    [Range(0.1f,3f)]public float rotationSpeed;

    Animator animator;

    ScoreController score;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        score = GameObject.Find("MajorController").GetComponent<ScoreController>();

        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        transform.position = transform.position + transform.up * Mathf.Abs((Mathf.Sin(Time.time * flappingMoveSpeed) * Time.deltaTime * flappingDistance));

        int direction = 0;
        if (Input.GetKey(KeyCode.A))
            direction = 1;
        else if (Input.GetKey(KeyCode.D))
            direction = -1;
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            direction = 0;

        transform.Rotate(0,0,direction * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bread"))
        {
            Destroy(other.gameObject);
            score.DefScored(2);
        }
    }
}
