using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameScreen : BasicScreen
{
    [SerializeField] private TMP_Text _scoreText;

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        Subscribe();
        SetScreen();
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }
    private void Subscribe()
    {
        GameEvents.OnTimerUpdate += UpdateScore;
    }
    private void UnSubscribe()
    {
        GameEvents.OnTimerUpdate -= UpdateScore;
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
        UpdateScore(0);
    }

    private void UpdateScore(int score)
    {
        _textManager.SetText(score, _scoreText, false, "Score: ");
    }
}