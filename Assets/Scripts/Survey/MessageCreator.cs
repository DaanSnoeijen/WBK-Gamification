using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MessageCreator : MonoBehaviour
{
    [Header("Scroll view items")]
    [SerializeField] ScrollRect ScrollViewRect;
    [SerializeField] GameObject ScrollViewContent;

    [Header("Message prefabs")]
    [SerializeField] GameObject InnoMessage;
    [SerializeField] GameObject InnoTyping;
    [SerializeField] GameObject InnoGift;
    [SerializeField] GameObject InnoFinish;
    [SerializeField] GameObject UserMessage;
    [SerializeField] GameObject UserNumber;
    [SerializeField] GameObject ClosedAnswer;

    [Header("Add answers to survey checker")]
    [SerializeField] SurveyChecker SurveyChecker;

    [Header("For linking slider content dynamically")]
    [SerializeField] CircleSliderContentLinker SliderLinker;

    float scrollBottomPosition = 0;

    public void CreateInnoMessage(string text, MessageType type)
    {
        GameObject message;

        switch (type)
        {
            case MessageType.Gift:
                message = Instantiate(InnoGift, ScrollViewContent.transform);
                break;

            case MessageType.InfoGift:
                message = Instantiate(InnoGift, ScrollViewContent.transform);
                break;

            case MessageType.DebugFinish:
                message = Instantiate(InnoFinish, ScrollViewContent.transform);
                break;

            default:
                message = Instantiate(InnoMessage, ScrollViewContent.transform);
                break;
        }

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
        TMP_InputField field = message.GetComponentInChildren<TMP_InputField>();
        field.text = text;
        SurveyChecker.AddUserText(field);

        SetScrollBottom(message, true);
    }

    public void CreateUserNumberInput(int maxValue) 
    {
        SliderLinker.SetMaxValue(maxValue);
        GameObject message = Instantiate(UserNumber, ScrollViewContent.transform);
        SetScrollBottom(message, true);
    }

    public void CreateClosedAnswers(List<string> _answers)
    {
        GameObject message = new GameObject();

        foreach (string item in _answers)
        {
            message = Instantiate(ClosedAnswer, ScrollViewContent.transform);
            TextMeshProUGUI field = message.GetComponentInChildren<TextMeshProUGUI>();
            field.text = item;
        }

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
