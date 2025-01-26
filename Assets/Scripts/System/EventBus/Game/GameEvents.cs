using System;

public static class GameEvents
{
    public static event Action OnGameFinish;
    public static event Action<int> OnPointsUpdate;
    public static event Action<float> OnTimerUpdate;

    public static void FinishGame() => OnGameFinish?.Invoke();  
    public static void PointsUpdate(int newAmount) => OnPointsUpdate?.Invoke(newAmount);
    public static void TimerUpdate(float newAmount) => OnTimerUpdate?.Invoke(newAmount);
}