using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanelUI : MonoBehaviour {
    Scrollbar healthBar;
    ColorBlock blue = new ColorBlock();
    ColorBlock red = new ColorBlock();
    private void Start()
    {
        EventHandler.OnMovingBlock += UpdateHealthBar;
        EventHandler.OnFlameCollected += UpdateHealthBar;
    }
    void OnDestroy()
    {
        EventHandler.OnMovingBlock -= UpdateHealthBar;
        EventHandler.OnFlameCollected -= UpdateHealthBar;
    }
	public void Initialise()
    {
        blue.disabledColor = new Color(0.4f,0.4f,0.71f,1f);
        blue.colorMultiplier = 1f;
        red.disabledColor = new Color(0.8f,0.27f,0.29f,1f);
        red.colorMultiplier = 1f;
        healthBar = GetComponent<Scrollbar>();
        healthBar.size = 0;
        healthBar.colors = red;
    }

    void UpdateHealthBar()
    {
        healthBar.size = (float)Player.instance.CurrentHealth / 6; //cast to float to get a float number
        if (healthBar.size <= 0.4f)
            healthBar.colors = blue;
        else
            healthBar.colors = red;
    }

}
