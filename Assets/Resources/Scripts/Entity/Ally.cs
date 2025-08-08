using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Ally : Entity
{
    [SerializeField]
    private RadialLayout layout;
    [SerializeField]
    private GameObject actionButton;
    public override void SetUp()
    {
        foreach (var item in data.actions)
        {
            item.owner = this;
            var button = Instantiate(actionButton, layout.transform).GetComponent<Button>();
            button.onClick.AddListener(() => SelectAction(item));
        }
        layout.gameObject.SetActive(false);
    }

    public override void UnSelect()
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
        ).OnComplete(() => { layout.gameObject.SetActive(false); });
    }

    public override void Select()
    {
        layout.gameObject.SetActive(true);
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
}
