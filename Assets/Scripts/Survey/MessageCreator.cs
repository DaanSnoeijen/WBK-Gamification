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
    [SerializeField] GameObject UserMessage;

    float scrollBottomPosition = 0;

    public GameObject CreateInnoMessage(string text)
    {
        GameObject message = Instantiate(InnoMessage, ScrollViewContent.transform);
        message.GetComponentInChildren<TextMeshProUGUI>().text = text;

        Canvas.ForceUpdateCanvases();
        message.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputVertical();
        message.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        SetScrollBottom();
        return message;
    }

    public void CreateUserMessage(string text)
    {
        GameObject message = Instantiate(UserMessage, ScrollViewContent.transform);
        message.GetComponentInChildren<TextMeshProUGUI>().text = text;

        Canvas.ForceUpdateCanvases();
        message.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        message.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        SetScrollBottom();
    }

    void SetScrollBottom()
    {
        ScrollViewRect.content.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        ScrollViewRect.content.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        ScrollViewRect.verticalNormalizedPosition = scrollBottomPosition;
    }
}
