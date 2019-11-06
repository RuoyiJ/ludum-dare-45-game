using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour {
    [SerializeField]
    RectTransform HintsPanel;
    void Start()
    {
        if (PlayerPrefs.HasKey("Started"))
            HideHints();
        else
        {
            OpenHints();
            PlayerPrefs.SetInt("Started", 1);
            PlayerPrefs.Save();
        }
    }
	public void OpenHints()
    {
        HintsPanel.gameObject.SetActive(true);
    }
    public void HideHints()
    {
        HintsPanel.gameObject.SetActive(false);

    }
}
