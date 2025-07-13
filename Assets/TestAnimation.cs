using EditorAttributes;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class TestAnimation : MonoBehaviour
{

    RadialLayout layout;

    void Awake()
    {
        layout = GetComponent<RadialLayout>();
    }

    [Button]
    public void Open()
    {
        Tween.Custom(
            0f, 0.8f,
            duration: 0.2f,
            onValueChange: val =>
            {
                layout.fDistance = val;
                layout.Rebuild();
            },
            ease: Ease.OutSine
        );
    }

    [Button]
    public void Close()
    {
        Tween.Custom(
            0.8f, 0f,
            duration: 0.2f,
            onValueChange: val =>
            {
                layout.fDistance = val;
                layout.Rebuild();
            },
            ease: Ease.InSine
        );
    }
}
