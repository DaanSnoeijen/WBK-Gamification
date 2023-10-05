using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MessageCreator : MonoBehaviour
{
    [Header("Scroll view items")]
    [SerializeField] ScrollRect ScrollViewRect;
    [SerializeField] GameObject ScrollViewContent;

    [Header("Message prefabs")]
    [SerializeField] GameObject InnoMessage;
    [SerializeField] GameObject UserMessage;

    float scrollBottomPosition = 0;

    private void Start()
    {
        CreateInnoMessage("Test 1");
        CreateUserMessage("Test 2");
        CreateInnoMessage("Test 3");
        CreateInnoMessage("Lange tekst test. Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " +
            "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");
        CreateUserMessage("Test 2");
        CreateInnoMessage("Test 3");
        CreateInnoMessage("Test 1");
        CreateUserMessage("Test 2");
        CreateInnoMessage("Test 3");
    }

    public void CreateInnoMessage(string text)
    {
        GameObject message = Instantiate(InnoMessage, ScrollViewContent.transform);
        message.GetComponentInChildren<TextMeshProUGUI>().text = text;

        Canvas.ForceUpdateCanvases();
        message.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputVertical();
        message.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        SetScrollBottom();
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
