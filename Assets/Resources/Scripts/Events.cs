using System;

public static class Events
{
    public static Action<BattleData> OnBattleInit;
    public static Action<BattleData> OnBattleStart;
    public static Action<BattleData> OnBattleEnd;

    public static Action<CampaignData> OnCampaignInit;
    public static Action<CampaignData> OnCampaignStart;
    public static Action<CampaignData> OnCampaignEnd;

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
    public static void InvokeOnCampaignInit(CampaignData data)
    {
        OnCampaignInit?.Invoke(data);
    }
    public static void InvokeOnCampaignStart(CampaignData data)
    {
        OnCampaignStart?.Invoke(data);
    }
    public static void InvokeOnCampaignEnd(CampaignData data)
    {
        OnCampaignEnd?.Invoke(data);
    }
}
