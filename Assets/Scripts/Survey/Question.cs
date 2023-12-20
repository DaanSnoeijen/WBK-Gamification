using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum MessageType{
    OpenQuestion,
    NumberQuestion,
    MultipleChoice,
    MapQuestion,
    Message,
    Gift,
    InfoGift,
    DebugFinish
}

[System.Serializable]
public class Question
{
    [Header("What type of message will it be?")]
    public MessageType type;

    [Header("What will the text in the message be?")]
    [TextArea(3, 20)]
    public string text;

    [Header("Max value for slider. Only applicable for number question")]
    public int maxValue;

    [Header("Closed answers. Only applicable for multiple choice question")]
    public List<string> _answers;
    public bool isRadioButton;
    public bool userCanSendMessage = true;

    [Header("Is the open question long or short?")]
    public bool isShort;
}
