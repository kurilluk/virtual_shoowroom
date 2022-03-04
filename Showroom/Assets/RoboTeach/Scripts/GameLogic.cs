using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Target target;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] private Canvas canvas;


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
        canvas.gameObject.SetActive(true);
        //Debug.Log("The score should be displayed now.");
        int numberOfTargets = target.levelPositions.Length;
        int actualTargetIndex = target.acturalTargetIndex + 1;
        if (actualTargetIndex == numberOfTargets){
            scoreText.text = "Congratulations! You won! " + actualTargetIndex + " / " + numberOfTargets;
            ResetGame();
        }else {
            scoreText.text = "Good job! " + actualTargetIndex + " / " + numberOfTargets;
        }
        yield return new WaitForSeconds(2f);
        scoreText.text = "";
        canvas.gameObject.SetActive(false);
    }

    private void OmDisable()
    {
        target.ShowScore -= DisplayScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
        canvas.gameObject.SetActive(false);
    }

    private void ResetGame() 
    {
        StartCoroutine(ReloadLevel());
    }

    IEnumerator ReloadLevel() 
    {
        yield return new WaitForSeconds(5f);
        canvas.gameObject.SetActive(true);
        scoreText.text = "Reloading the game!";
        yield return new WaitForSeconds(2f);
        scoreText.text = "";
        canvas.gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(1, UnloadSceneOptions.None);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

}
