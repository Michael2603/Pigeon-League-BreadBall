using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    MajorController majorController;

    int defendersPoints = 0;
    int attackersPoints = 0;

    [SerializeField] Text defendersScoreText;
    [SerializeField] Text attackersScoreText;

    void Start()
    {
        majorController = GetComponent<MajorController>();
    }
 
    void Update()
    {
        if (defendersPoints >= 5)
        {
            majorController.TransitionRunner();
        }
        else if (attackersPoints == 5)
        {
            Debug.Log("Attackers Win");
        }

        defendersScoreText.text = defendersPoints.ToString();
        attackersScoreText.text = attackersPoints.ToString();
    }

    public void DefScored(int points)
    {
        defendersPoints += points;
    }

    public void AtkScored(int points)
    {
        attackersPoints += points;
    }
}
