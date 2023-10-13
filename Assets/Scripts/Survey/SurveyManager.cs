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

    int listId = 0;

    float waitInBetween = 0.8f;
    float waitTyping = 2f;

    private void Start()
    {
        NextMessage();
    }

    public void NextMessage()
    {
        InputManager.ToggleSending(false);
        ProgressBarSetter.SetProgressBar((float)listId / _questions.Count);
        listId++;

        if (listId <= _questions.Count) StartCoroutine(IShowMessage());
        else ProgressBarSetter.SetProgressBar(1f);
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
            MessageCreator.CreateInnoMessage(question.text, MessageType.Finish);
            ExitButton.SetActive(false);
            EndButton.SetActive(true);

            yield break;
        }
        MessageCreator.CreateInnoMessage(question.text, question.type);

        if (question.type == MessageType.Encouragement ||
            question.type == MessageType.Gift ||
            question.type == MessageType.Finish) NextMessage();
        else InputManager.ToggleSending(true);
    }
}
