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
    private GameObject displayPanel;
    [SerializeField]
    private CardDisplay cardDisplay;
    [SerializeField]
    private EntityDisplayInspect entityDisplay;

    private CardData _card;
    private EntityData _entity;
    public ContainerDisplay containerDisplay;

    public void Clear()
    {
        cardDisplay.gameObject.SetActive(false);
        entityDisplay.gameObject.SetActive(false);
        displayPanel.SetActive(false);
        _card = null;
        _entity = null;

        popUpContainter.Clear();
    }
    public void Inspect(Card card)
    {
        _card = card.data;
        cardDisplay.SetData(_card);

        var keywords = GetKeywords(_card.description);
        foreach (var item in keywords)
        {
            popUpContainter.Spawn(item);
        }

        cardDisplay.gameObject.SetActive(true);
        displayPanel.SetActive(true);
    }
    public void Inspect(Entity entity)
    {
        _entity = entity.data;
        entityDisplay.SetData(entity);

        var keywords = GetKeywords(_entity.description);
        foreach (var item in keywords)
        {
            popUpContainter.Spawn(item);
        }

        entityDisplay.gameObject.SetActive(true);
        displayPanel.SetActive(true);
    }
    public KeywordData[] GetKeywords(string description)
    {
        var tags = GetKeywordTags(description);

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
