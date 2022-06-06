using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorController : MonoBehaviour
{
    [Header("Breadbee")]
    public GameObject breadBee;
    public GameObject breads;
    public GameObject bluePivot;

    [Header("Runner")]
    public GameObject runner;
    public Transform bradTransform;
    public Transform pivotTransform;
    public GameObject letterHUD;

    public void TransitionRunner()
    {
        foreach(Transform bread in breads.transform)
        {
            Destroy(bread.gameObject);
        }

        bluePivot.transform.position = new Vector3(-2.06299996f,-0.946999907f,0);

        breadBee.SetActive(false);
        runner.SetActive(true);
    }

    public void TransitionBreadbee()
    {
        bradTransform.localPosition = new Vector3(0, -3.62f, 0);
        pivotTransform.localPosition = new Vector3(-7, -2f, 0);
        
        bradTransform.gameObject.GetComponent<PlayableBread>().speedCounter = bradTransform.gameObject.GetComponent<PlayableBread>().maxSpeed;

        letterHUD.SetActive(false);
        runner.SetActive(false);
        breadBee.SetActive(true);
    }
}