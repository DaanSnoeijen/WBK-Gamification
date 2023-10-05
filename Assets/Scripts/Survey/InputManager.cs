using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Able to send messages")]
    [SerializeField] MessageCreator MessageCreator;
    [SerializeField] TMP_InputField InputField;

    public void SendUserMessage()
    {
        if (InputField.text != "")
        {
            MessageCreator.CreateUserMessage(InputField.text);
            InputField.text = "";
        }
    }

    public void AbleToSend(bool state)
    {
        //Set if user is able to send a message or continue through the send button
    }
}
