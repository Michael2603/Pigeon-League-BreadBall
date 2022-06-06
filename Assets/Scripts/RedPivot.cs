using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedPivot : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public GameObject brad;
    public MajorController majorController;

    public GameObject buttonSprite;
    public Text textUI;
    
    public float delayShowText;

    float randomQTETimer;
    bool quickTimeEventCalled;

    bool canType = false;

    bool rightKey = false;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        randomQTETimer = Random.Range(4, 8);
    }


    void FixedUpdate()
    {
        randomQTETimer -= Time.deltaTime;

        if ( (randomQTETimer <= 0 || brad.transform.localPosition.x <= transform.localPosition.x + 3) && !quickTimeEventCalled)
        {
            quickTimeEventCalled = true;
            GetComponent<Animator>().SetTrigger("StartAttack");
        }
    }

    void Update()
    {
        rigidbody2d.velocity = new Vector3(brad.GetComponent<PlayableBread>().maxSpeed - ( brad.GetComponent<PlayableBread>().maxSpeed * .1f), 0, 0);

        if (canType && textUI.text != "")
        {
            KeyCode textKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), textUI.text[0].ToString());
            
            if (Input.GetKeyDown(textKey))
            {
                rightKey = true;

                textUI.text = "";
                canType = false;
                buttonSprite.SetActive(false);

                quickTimeEventCalled = false;
                randomQTETimer = Random.Range(3, 8);

            }
            else if (Input.anyKey)
            {
                if (!Input.GetKeyDown(textKey))
                    rightKey = false;
                
                textUI.text = "";
                canType = false;
                buttonSprite.SetActive(false);
            }
        }
    }

    public void ShowLetterSprite()
    {
        buttonSprite.SetActive(true);
        textUI.text = "";
    }

    void QuickTimeEvent()
    {
        char[] letters = {'Q','W','E','A','S','D','Z','X','C'};        
        textUI.text += letters[Random.Range(0,9)];
        canType = true;
    }

    public void Attack()
    {
        textUI.text = "";
        canType = false;
        buttonSprite.SetActive(false);

        if (!rightKey)
        {
            transform.localPosition = new Vector3(brad.GetComponent<Transform>().localPosition.x - 3, transform.localPosition.y, 0);
        }
            
        quickTimeEventCalled = false;
        randomQTETimer = Random.Range(3, 8);
    }

    public void Transition()
    {
        if (!rightKey)
            majorController.TransitionBreadbee();
        else
            rightKey = false;
    }
}