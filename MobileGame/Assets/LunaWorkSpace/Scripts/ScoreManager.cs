using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public int scoreSize;
    public int scoreSizeOnPoint;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            IncreaseScore(10);
        }
    }
    public void IncreaseScore(float value)
    {
        score += value;
        UpdateText();
    }

    public void DecreaseSCore(float value)
    {
        score -= value;
        UpdateText();
    }

    public void UpdateText()
    {
        scoreText.text = score.ToString();
        StartCoroutine(ScoreAnimation());
    }

    IEnumerator ScoreAnimation()
    {
        scoreText.fontSize = scoreSizeOnPoint;
        yield return new WaitForSeconds(.2f);
        scoreText.fontSize = scoreSize;
    }
}
