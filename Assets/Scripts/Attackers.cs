using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour
{
    public GameObject bread;
    public float breadForce;

    float throwTimer = 3;

    void Start()
    {
        
    }

    void Update()
    {
        throwTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || throwTimer <= 0)
        {
            StraightPitch();
            GetComponent<Animator>().SetTrigger("Throw");
            throwTimer = Random.Range(3f,6f);
        }
    }

    void StraightPitch()
    {
        GameObject breadsParent = GameObject.Find("Breads");
        GameObject tmp_bread = Instantiate(bread, transform.position, transform.rotation, breadsParent.transform);
        tmp_bread.GetComponent<Rigidbody2D>().AddForce(transform.right * breadForce);
    }

    void CurvePitch()
    {

    }
}
