using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunProgression : MonoBehaviour
{
    public Slider slider;
    public Transform finishLinePos;
    public Transform bradPos;

    void Update()
    {
        // Set slider value by the percentage of conclusion from Brad to finish line
        slider.value = ( (bradPos.localPosition.x * 100) /  finishLinePos.localPosition.x / 100 );

        if (slider.value >= 1)
            GameObject.Find("MajorController").GetComponent<MajorController>().TransitionBreadbee();

    }
}
