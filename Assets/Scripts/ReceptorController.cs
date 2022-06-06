using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorController : MonoBehaviour
{
    ScoreController score;
    
    void Start()
    {
        score = GameObject.Find("MajorController").GetComponent<ScoreController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Bread"))
        {
            GetComponent<Animator>().SetTrigger("Receive");

            Destroy(other.gameObject);
            score.AtkScored(2);
        }
    }
}
