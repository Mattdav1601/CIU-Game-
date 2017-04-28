using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    // Button variables
    public Button[] buttons;
    private Button currentButton;

    // Colour variables
    private ColorBlock[] colourBlocks;

    // Image variables
    private Image[] buttonColours;

    // Scroll variables
    public float axisSensitivity = 0.1f;
    public float scrollWaitTime = 0.2f;

    // Input variables

    // Index variables
    private int buttonIndex;

    // Bool variables
    private bool canScroll = true;
    #endregion

    private void Start()
    {
        // Set array length
        buttonColours = new Image[buttons.Length];
        colourBlocks = new ColorBlock[buttons.Length];

        // Set current button to first button in array
        currentButton = buttons[0];

        // Get components, set colours
        for (int buttonIndex = 0; buttonIndex < buttons.Length; ++buttonIndex)
        {
            colourBlocks[buttonIndex] = buttons[buttonIndex].colors;
            buttonColours[buttonIndex] = buttons[buttonIndex].GetComponent<Image>();
        }
    }

    private void Update()
    {
        UpdateInput();
        ClampButtonIndex();
        UpdateButton();
    }

    private void UpdateInput()
    {
        // Check if can scroll
        if (canScroll)
        {
            // Check input and adjust button index
            if (Input.GetAxisRaw("Vertical") > axisSensitivity)
            {
                StartCoroutine(ButtonScrollWait());
                --buttonIndex;
            }
            if (Input.GetAxisRaw("Vertical") < -axisSensitivity)
            {
                StartCoroutine(ButtonScrollWait());
                ++buttonIndex;
            }
        }

        // Check for input
        if (Input.GetButtonDown("Submit"))
        {
            // Run OnClick button event
            currentButton.onClick.Invoke();
        }
    }

    private void ClampButtonIndex()
    {
        // Clamp button index
        if (buttonIndex > buttons.Length - 1)
        {
            buttonIndex = 0;
        }
        if (buttonIndex < 0)
        {
            buttonIndex = buttons.Length - 1;
        }
    }

    public void JUSTRUN()
    {
        print("IRAN");
    }

    private void UpdateButton()
    {
        // Set current button
        currentButton = buttons[buttonIndex];

        // Alter colors based on state of button
        for (int buttonIndex = 0; buttonIndex < buttons.Length; buttonIndex++)
        {
            if (buttons[buttonIndex] == currentButton)
            {
                buttonColours[buttonIndex].color = colourBlocks[buttonIndex].highlightedColor;
            }
            else
            {
                buttonColours[buttonIndex].color = colourBlocks[buttonIndex].normalColor;
            }
        }
    }

    private IEnumerator ButtonScrollWait()
    {
        // Timer
        canScroll = false;
        yield return new WaitForSeconds(scrollWaitTime);
        canScroll = true;
    }
}

