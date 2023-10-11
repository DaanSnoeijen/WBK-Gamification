using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageCreator : MonoBehaviour
{
    [Header("Scroll view items")]
    [SerializeField] ScrollRect ScrollViewRect;
    [SerializeField] GameObject ScrollViewContent;

    [Header("Message prefabs")]
    [SerializeField] GameObject InnoMessage;
    [SerializeField] GameObject InnoTyping;
    [SerializeField] GameObject InnoGift;
    [SerializeField] GameObject UserMessage;

    float scrollBottomPosition = 0;

    public void CreateInnoMessage(string text, MessageType type)
    {
        GameObject message;

        if (type == MessageType.Gift) message = Instantiate(InnoGift, ScrollViewContent.transform);
        else message = Instantiate(InnoMessage, ScrollViewContent.transform);
        message.GetComponentInChildren<TextMeshProUGUI>().text = text;

        SetScrollBottom(message, false);
    }

    public GameObject CreateInnoTyping()
    {
        GameObject message = Instantiate(InnoTyping, ScrollViewContent.transform);

        SetScrollBottom(message, false);
        return message;
    }

    public void CreateUserMessage(string text)
    {
        GameObject message = Instantiate(UserMessage, ScrollViewContent.transform);
        message.GetComponentInChildren<TextMeshProUGUI>().text = text;

        SetScrollBottom(message, true);
    }

    void SetScrollBottom(GameObject message, bool layoutGroupVertical)
    {
        Canvas.ForceUpdateCanvases();
        if (layoutGroupVertical) message.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        else message.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputVertical();
        message.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        ScrollViewRect.content.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        ScrollViewRect.content.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        ScrollViewRect.verticalNormalizedPosition = scrollBottomPosition;
    }
}
