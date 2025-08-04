using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Card))]
public class CardDisplay : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI title;
	[SerializeField]
	private Image sprite;
	[SerializeField]
	private TextMeshProUGUI desc;
	private CardData data => GetComponent<Card>().data;
	public float scale;
	public bool promptUpdate;

	void Start()
	{
		promptUpdate = true;
	}

	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			transform.localScale = Vector3.one * scale;
			UpdateDisplay();
		}
	}

	void UpdateDisplay()
	{
		title.text = data.title;
		sprite.sprite = data.sprite;
		desc.text = data.description;
	}
}