using UnityEngine;
using UnityEngine.UI;

public class PopUpContainter : MonoBehaviour
{
	[SerializeField]
	private GameObject columnObj;
	[SerializeField]
	private GameObject popUpObj;
	private RectTransform _currentColumn;

	public void Spawn(KeywordData keyword)
	{
		if (_currentColumn == null || _currentColumn.rect.height >= 850)
		{
			_currentColumn = Instantiate(columnObj, transform).GetComponent<RectTransform>();
		}

		var popUp = Instantiate(popUpObj, _currentColumn).GetComponent<PopUp>();
		popUp.SetKeyword(keyword);
		popUp.promptUpdate = true;
		LayoutRebuilder.ForceRebuildLayoutImmediate(_currentColumn);
	}
	public void Clear()
	{
		_currentColumn = null;
		foreach (Transform item in transform)
		{
			Destroy(item.gameObject);
		}
	}
}