using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
	private KeywordData _data;
	[SerializeField]
	private TextMeshProUGUI titleText;
	[SerializeField]
	private TextMeshProUGUI descText;
	public bool promptUpdate;

	public void SetKeyword(KeywordData data)
	{
		_data = data;
	}

	void Update()
	{
		if (promptUpdate)
		{
			promptUpdate = false;
			titleText.text = _data.title;
			descText.text = _data.desc;
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}
	}
}