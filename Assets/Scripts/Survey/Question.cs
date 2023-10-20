using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum MessageType{
    OpenQuestion,
    NumberQuestion,
    MultipleChoice,
    Encouragement,
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

    [Header("Max value for slider. Only applicable with Number Question")]
    public int maxValue;
}
