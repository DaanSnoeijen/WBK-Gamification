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
    [SerializeField] GameObject InnoFinish;
    [SerializeField] GameObject UserMessage;
    [SerializeField] GameObject UserNumber;
    [SerializeField] GameObject UserClosedAnswer;
    [SerializeField] GameObject UserMap;
    [SerializeField] GameObject SpaceFiller;

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

        SetScrollBottom(message, 0);
    }

    public GameObject CreateInnoTyping()
    {
        GameObject message = Instantiate(InnoTyping, ScrollViewContent.transform);

        SetScrollBottom(message, 0);
        return message;
    }

    public void CreateUserMessage(string text)
    {
        GameObject message = Instantiate(UserMessage, ScrollViewContent.transform);
        TMP_InputField field = message.GetComponentInChildren<TMP_InputField>();
        field.text = text;
        SurveyChecker.AddUserText(field);

        SetScrollBottom(message, 1);

        StartCoroutine(ICheckQuestionMessage(text));

        Instantiate(SpaceFiller, ScrollViewContent.transform);
    }

    public void CreateUserNumberInput(int maxValue) 
    {
        SliderLinker.SetMaxValue(maxValue);
        GameObject message = Instantiate(UserNumber, ScrollViewContent.transform);
        SetScrollBottom(message, 1);

        Instantiate(SpaceFiller, ScrollViewContent.transform);
    }

    public void CreateClosedAnswers(List<string> _answers, bool isRadio) { StartCoroutine(IClosedAnswerAnim(_answers, isRadio)); }

    public void CreateUserMap()
    {
        GameObject message = Instantiate(UserMap, ScrollViewContent.transform);
        SetScrollBottom(message, 2);

        Instantiate(SpaceFiller, ScrollViewContent.transform);
    }

    void SetScrollBottom(GameObject message, int layoutGroup)
    {
        Canvas.ForceUpdateCanvases();
        if (layoutGroup == 0) message.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputVertical();
        else if (layoutGroup == 1) message.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        if (layoutGroup != 2) message.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        ScrollViewRect.content.GetComponent<VerticalLayoutGroup>().CalculateLayoutInputVertical();
        ScrollViewRect.content.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        ScrollViewRect.verticalNormalizedPosition = scrollBottomPosition;
    }

    IEnumerator IClosedAnswerAnim(List<string> _answers, bool isRadio)
    {
        List<ClosedQuestionLogic> closedQuestions = new List<ClosedQuestionLogic>();

        foreach (string item in _answers)
        {
            GameObject message = Instantiate(UserClosedAnswer, ScrollViewContent.transform);
            message.GetComponentInChildren<ClosedQuestionLogic>().SetType(isRadio);
            TextMeshProUGUI field = message.GetComponentInChildren<TextMeshProUGUI>();
            field.text = item;

            closedQuestions.Add(message.GetComponentInChildren<ClosedQuestionLogic>());

            SetScrollBottom(message, 1);
            yield return new WaitForSeconds(0.3f);
        }

        foreach (var item in closedQuestions) item.SetAnswerGroup(closedQuestions);

        Instantiate(SpaceFiller, ScrollViewContent.transform);
    }

    IEnumerator ICheckQuestionMessage(string text)
    {
        if (text.Contains("?"))
        {
            yield return new WaitForSeconds(2.79f);

            CreateInnoMessage("Sorry, maar ik kan geen vragen beantwoorden. " +
            "Tik op uw bericht om deze aan te passen.", MessageType.Message);
        }
    }
}
