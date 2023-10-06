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
    [SerializeField] Image ProgressBar;

    int listId = 0;

    private void Start()
    {
        NextMessage();
    }

    public void NextMessage()
    {
        InputManager.ToggleSending(false);
        ProgressBar.fillAmount = (float)listId / _questions.Count;
        listId++;

        if (listId <= _questions.Count) StartCoroutine(ShowMessage());
        else 
        {
            ProgressBar.fillAmount = 1f;
            //End survey
        }
    }

    IEnumerator ShowMessage()
    {
        yield return new WaitForSeconds(1f);

        GameObject loadMessage = MessageCreator.CreateInnoMessage(". . .");
        yield return new WaitForSeconds(2f);
        Destroy(loadMessage);

        MessageCreator.CreateInnoMessage(_questions[listId - 1].text);

        if (_questions[listId - 1].type == MessageType.Encouragement ||
            _questions[listId - 1].type == MessageType.Gift) NextMessage();
        else InputManager.ToggleSending(true);
    }
}
