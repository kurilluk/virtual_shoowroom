using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public Target target;
    [SerializeField] public TextMeshProUGUI scoreText;


    private void OmEnable()
    {
        target.ShowScore += DisplayScore;
    }

    public void DisplayScore()
    {
        StartCoroutine(ShowScoreText());
    }
    IEnumerator ShowScoreText() 
    {
        Debug.Log("The score should be displayed now.");
        int numberOfTargets = target.levelPositions.Length;
        int actualTargetIndex = target.acturalTargetIndex + 1;
        if (actualTargetIndex == numberOfTargets)
        {
            scoreText.text = "Congratulations! You won! " + actualTargetIndex + " / " + numberOfTargets;
        }
        else 
        {
            scoreText.text = "Good job! " + actualTargetIndex + " / " + numberOfTargets;
        }

        yield return new WaitForSeconds(2f);
        scoreText.text = "";
    }

    private void OmDisable()
    {
        target.ShowScore -= DisplayScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
    }

}
