using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Try to make the game as simple as possible, not using this anymore
public class GridButton : MonoBehaviour {
    Image buttonImage;
    bool enable = false;
    Text buttonText;
    string gridOn = "Grid On";
    string gridOff = "Grid Off";
    Color onColor = new Color(0.6f, 0.83f, 0.95f, 1f);
    Color offColor = new Color(0.35f, 0.46f, 0.62f, 1f);

    [SerializeField]
    Button pinkButton, yellowButton, blueButton, purpleButton, greenButton,defaultButton;
    Button currButton;
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<Text>();
       
        buttonText.text = gridOn;
        buttonImage.color = offColor;
        ChangeColorButtonsState(false);
        currButton = defaultButton;
    }
    public void ChangeButtonState()
    {
        enable = !enable;
        // if grid is shown, change button color brighter and text to "Grid Off", and show color selections
        // else change it back
        if (enable)
        {
            buttonText.text = gridOff;
            buttonImage.color = onColor;
            DisableAllButSelected();
        }
        else
        {
            buttonText.text = gridOn;
            buttonImage.color = offColor;
        }
        ChangeColorButtonsState(enable);
    }
    void ChangeColorButtonsState(bool show)
    {
        pinkButton.gameObject.SetActive(show);
        yellowButton.gameObject.SetActive(show);
        blueButton.gameObject.SetActive(show);
        purpleButton.gameObject.SetActive(show);
        greenButton.gameObject.SetActive(show);
        defaultButton.gameObject.SetActive(show);
    }

    public void PressPink()
    {
        currButton = pinkButton;
        DisableAllButSelected();
    }
    public void PressYellow()
    {
        currButton = yellowButton;
        DisableAllButSelected();

    }
    public void PressBlue()
    {
        currButton = blueButton;
        DisableAllButSelected();

    }
    public void PressPurple()
    {
        currButton = purpleButton;
        DisableAllButSelected();

    }
    public void PressGreen()
    {
        currButton = greenButton;
        DisableAllButSelected();

    }
    public void PressDefault()
    {
        currButton = defaultButton;
        DisableAllButSelected();

    }

    void DisableAllButSelected()
    {
        pinkButton.GetComponent<Image>().enabled = false;
        yellowButton.GetComponent<Image>().enabled = false;
        blueButton.GetComponent<Image>().enabled = false;
        purpleButton.GetComponent<Image>().enabled = false;
        greenButton.GetComponent<Image>().enabled = false;
        defaultButton.GetComponent<Image>().enabled = false;
        if (currButton != null)
            currButton.GetComponent<Image>().enabled = true;
    }
}
