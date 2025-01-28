using System;

public static class GameEvents
{
    public static event Action OnGameFinish;
    public static event Action OnGameStart;
    public static event Action<int> OnTimerUpdate;
    public static event Action<float> OnDificultyCoeficientUpdate;
    public static event Action<ObstaclesController> OnObstaclesDestroy;

    public static void FinishGame() => OnGameFinish?.Invoke(); 
    public static void StartGame() => OnGameStart?.Invoke();
    public static void UpdateTimer(int newAmount) => OnTimerUpdate?.Invoke(newAmount);
    public static void UpdateDificultyCoeficient(float newAmount) => OnDificultyCoeficientUpdate?.Invoke(newAmount);
    public static void DestroyObstacle(ObstaclesController obstaclesController) => OnObstaclesDestroy?.Invoke(obstaclesController);
}