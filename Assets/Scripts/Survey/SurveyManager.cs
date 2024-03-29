using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyManager : MonoBehaviour
{
    [Header("In here you can input the entire survey")]
    [SerializeField] List<Question> _questions;

    [Header("Creating messages and toggling user input")]
    [SerializeField] MessageCreator MessageCreator;
    [SerializeField] InputManager InputManager;

    [Header("Progress tracker")]
    [SerializeField] ProgressBarSetter ProgressBarSetter;

    [Header("Exit button switch when finished")]
    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject EndButton;

    [Header("Info about coins")]
    [SerializeField] BackButtonLogic CoinInfo;

    int listId = 0;
    int questionAmount;

    float questionId;

    float waitInBetween = 1f;
    float waitTyping = 2f;

    bool choiceOpen;

    private void Start()
    {
        foreach (Question item in _questions) if (item.type == MessageType.OpenQuestion ||
                item.type == MessageType.NumberQuestion ||
                item.type == MessageType.MapQuestion ||
                item.type == MessageType.MultipleChoice) questionAmount++;

        ProgressBarSetter.SetQuestionsTotal(questionAmount);
    }

    public void NextMessage()
    {
        InputManager.ToggleSending(false);
        listId++;

        if (listId == _questions.Count) ProgressBarSetter.SetProgressBar(1f);
        else if (questionId > 0) ProgressBarSetter.SetProgressBar(questionId / questionAmount);
        ProgressBarSetter.SetQuestionsLeft((int)questionId);

        StartCoroutine(IShowMessage());
    }

    IEnumerator IShowMessage()
    {
        yield return new WaitForSeconds(waitInBetween);

        GameObject loadMessage = MessageCreator.CreateInnoTyping();
        yield return new WaitForSeconds(waitTyping);
        Destroy(loadMessage);

        Question question = _questions[listId - 1];
        if (listId == _questions.Count)
        {
            MessageCreator.CreateInnoMessage(question.text, MessageType.DebugFinish);
            ExitButton.SetActive(false);
            EndButton.SetActive(true);

            yield break;
        }
        MessageCreator.CreateInnoMessage(question.text, question.type);
        choiceOpen = question.userCanSendMessage;

        if (question.type == MessageType.Message ||
            question.type == MessageType.DebugFinish) NextMessage();

        else if (question.type == MessageType.NumberQuestion) MessageCreator.CreateUserNumberInput(question.maxValue);
        else if (question.type == MessageType.MultipleChoice) MessageCreator.CreateClosedAnswers(question._answers, question.isRadioButton, choiceOpen);
        else if (question.type == MessageType.MapQuestion) MessageCreator.CreateUserMap();
        else if (question.type == MessageType.OpenQuestion)
        {
            MessageCreator.CreateUserMessage(question.isShort);
            InputManager.ToggleSending(true);
        }

        IncreaseProgressBarID(question);

        if (question.type == MessageType.InfoGift) CoinInfo.ShowCloseScreen(true);
    }

    void IncreaseProgressBarID(Question question)
    {
        if (question.type == MessageType.OpenQuestion ||
            question.type == MessageType.NumberQuestion ||
            question.type == MessageType.MapQuestion ||
            question.type == MessageType.MultipleChoice) questionId++;
    }
}
