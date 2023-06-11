using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreView : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text heartText;
    [SerializeField] TMP_Text goldText;


    private void OnEnable()
    {
        GameManager.Data.OnCurrentScoreChanged += ChangeScore;
        GameManager.Data.OnHeartPointChanged += ChangeHeartPoint;
        GameManager.Data.OnGoldChanged += ChangeGold;
    }

    private void OnDisable()
    {
        GameManager.Data.OnCurrentScoreChanged -= ChangeScore;
        GameManager.Data.OnHeartPointChanged -= ChangeHeartPoint;
        GameManager.Data.OnGoldChanged -= ChangeGold;
    }

    private void ChangeScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private void ChangeHeartPoint(int heartPoint)
    {
        heartText.text = heartPoint.ToString();
    }

    private void ChangeGold(int gold)
    {
        goldText.text = gold.ToString();
    }
}
