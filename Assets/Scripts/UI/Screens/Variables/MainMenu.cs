using UnityEngine;
using UnityEngine.UI;

public class MainMenu : BasicScreen
{
    [SerializeField] private Button _levelButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        _levelButton.onClick.AddListener(Levels);
        _exitButton.onClick.AddListener(Exit);
    }

    private void UnSubscribe()
    {
        _levelButton.onClick.RemoveListener(Levels);
        _exitButton.onClick.RemoveListener(Exit);
    }

    public override void ResetScreen()
    {
    }

    public override void SetScreen()
    {
    }

    private void Levels()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Levels);
    }

    private void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}