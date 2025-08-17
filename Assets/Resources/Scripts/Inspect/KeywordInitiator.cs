using System.Collections.Generic;
using UnityEngine;

public class KeywordInitiator : MonoBehaviour
{
	[SerializeField]
	private List<KeywordData> keywords = new List<KeywordData>();
	void Awake()
	{
		foreach (var item in keywords)
		{
			KeywordManager.Add(item);
		}
	}
}