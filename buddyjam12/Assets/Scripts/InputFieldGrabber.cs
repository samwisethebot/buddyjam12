using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldGrabber : MonoBehaviour
{
    [SerializeField] private string inputText; //Value received

    [Header("Showing the reaction to the player")]
    [SerializeField] private GameObject reactionGroup; 
    [SerializeField] private TMP_Text reactionTextBox;

    [Header("Value")]
    [SerializeField] public float inputParsedAsFloat;

    public void GrabFromInputField (string input)
    {
        inputText = input;

        inputParsedAsFloat = float.Parse(input);
       // DisplayReactionToInput(); if we want a pop up or something
    }

    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "Reaction";
        reactionGroup.SetActive(true);
    }
}
