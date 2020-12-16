﻿using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreDisplay scoreDisplay = default;

    [SerializeField] int deletedRowBaseValue = 10;

    public int Score { get; private set; }

    public void OnRowDeleted(int comboIndex)
    {
        int scoreIncrease = comboIndex * deletedRowBaseValue;

        Score += scoreIncrease;

        StartCoroutine(scoreDisplay.AddScoreAnimation(scoreIncrease));
    }
}
