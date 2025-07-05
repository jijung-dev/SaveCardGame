using System;

public static class Events
{
    public static Action<BattleData> OnBattleInit;
    public static Action<BattleData> OnBattleStart;
    public static Action<BattleData> OnBattleEnd;

    public static void InvokeOnBattleInit(BattleData data)
    {
        OnBattleInit?.Invoke(data);
    }
    public static void InvokeOnBattleStart(BattleData data)
    {
        OnBattleStart?.Invoke(data);
    }
    public static void InvokeOnBattleEnd(BattleData data)
    {
        OnBattleEnd?.Invoke(data);
    }
}
