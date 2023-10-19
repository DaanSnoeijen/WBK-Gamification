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
    int questionAmount = 0;

    float questionId = 0;

    float waitInBetween = 0.8f;
    float waitTyping = 2f;

    private void Start()
    {
        NextMessage();

        foreach (Question item in _questions) if (item.type == MessageType.OpenQuestion) questionAmount++;
    }

    public void NextMessage()
    {
        InputManager.ToggleSending(false);
        listId++;

        if (listId == _questions.Count) ProgressBarSetter.SetProgressBar(1f);
        else if (questionId > 0) ProgressBarSetter.SetProgressBar(questionId / questionAmount);

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

        if (question.type == MessageType.Encouragement ||
            question.type == MessageType.DebugFinish) NextMessage();
        else if (question.type != MessageType.Gift &&
            question.type != MessageType.FirstGift)
        {
            InputManager.ToggleSending(true);
            questionId++;
        }
        if (question.type == MessageType.FirstGift) CoinInfo.ShowCloseScreen(true);
    }
}
