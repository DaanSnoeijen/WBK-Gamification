using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageType{
    OpenQuestion,
    Encouragement,
    Gift
}

[System.Serializable]
public class Question
{
    [Header("What type of message will it be?")]
    public MessageType type;

    [Header("What will the text in the message be?")]
    public string text;
}
