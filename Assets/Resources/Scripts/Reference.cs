using UnityEngine;


public class Reference : MonoBehaviourSingleton<Reference>
{
    private static NodeSpawner _nodeSpawner;

    public static NodeSpawner nodeSpawner => _nodeSpawner;
    protected override void Awake()
    {
        base.Awake();
        Events.OnCampaignInit += (data) => InCampaign();
        Events.OnCampaignEnd += (data) => OutCampaign();
    }
    void InCampaign()
    {
        _nodeSpawner = FindByTag<NodeSpawner>("NodeSpawner");
    }
    void OutCampaign()
    {
        _nodeSpawner = null;
    }

    private T FindByTag<T>(string tag) where T : Component
    {
        var obj = GameObject.FindGameObjectWithTag(tag);
        return obj != null && obj.TryGetComponent<T>(out var component)
            ? component
            : null;
    }
}
