using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EditorAttributes;
using UnityEngine;

public class InspectSystem : MonoBehaviour
{
    [SerializeField]
    private PopUpContainter popUpContainter;
    [SerializeField]
    private CardContainer container;
    [SerializeField]
    private GameObject inspectPanel;

    private CardContainer preContainer;
    private Card _card;

    [Button(true)]
    public void Clear()
    {
        inspectPanel.SetActive(false);

        _card.container.Remove(_card);
        preContainer.Add(_card);
        _card.FlipUp();

        preContainer = null;
        _card = null;

        popUpContainter.Clear();
    }
    public void Inspect(Card card)
    {
        _card = card;
        preContainer = _card.container;
        _card.container.Remove(_card);
        container.Add(_card);

        _card.display.scale = 1.5f;
        _card.display.promptUpdate = true;

        var keywords = GetKeywords(_card.data);
        foreach (var item in keywords)
        {
            popUpContainter.Spawn(item);
        }

        inspectPanel.SetActive(true);
    }
    public KeywordData[] GetKeywords(CardData data)
    {
        var tags = GetKeywordTags(data.description);

        var keywords = new List<KeywordData>();
        foreach (var item in tags)
        {
            keywords.Add(KeywordManager.GetKeyword(item));
        }
        return keywords.ToArray();
    }
    public string[] GetKeywordTags(string text)
    {
        return Regex.Matches(text, "<([^<>]+)>")
                    .Cast<Match>()
                    .Select(m => m.Groups[1].Value.Trim())
                    .Distinct()
                    .ToArray();
    }
}
