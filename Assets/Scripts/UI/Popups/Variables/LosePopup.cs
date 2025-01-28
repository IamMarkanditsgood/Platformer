using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePopup : BasicPopup
{
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _exitGame;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _youLose;
    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
        TextManager textManager = new TextManager();
        int score = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.Score);

        textManager.SetText(score, _score, false, "Score: ");
        textManager.SetText("You Lose!", _youLose);
    }

    public override void Subscribe()
    {
        _restartGame.onClick.AddListener(RestartGame);
        _exitGame.onClick.AddListener(ExitGame);
    }
    public override void Unsubscribe()
    {
        _restartGame.onClick.RemoveListener(RestartGame);
        _exitGame.onClick.RemoveListener(ExitGame);
    }

    private void RestartGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
