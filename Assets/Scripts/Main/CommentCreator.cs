using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommentCreator : MonoBehaviour
{
    [Header("Comment to instantiate")]
    [SerializeField] GameObject Comment;
    [SerializeField] GameObject UserSubComment;

    [Header("Parent object")]
    [SerializeField] Transform Content;

    [Header("Input field")]
    [SerializeField] TMP_InputField UserInput;

    public void CreateComment()
    {
        GameObject NewComment = Instantiate(Comment, Content);

        List<TextMeshProUGUI> _Texts = NewComment.GetComponentsInChildren<TextMeshProUGUI>().ToList();
        _Texts.Find(x => x.name == "Name").text = "Guest276";
        _Texts.Find(x => x.name == "MessageText").text = UserInput.text;
        UserInput.text = "";
    }

    public void CreateSubComment(int id)
    {
        GameObject NewComment = Instantiate(UserSubComment, Content);
        NewComment.transform.SetSiblingIndex(id + 1);

        List<TextMeshProUGUI> _Texts = NewComment.GetComponentsInChildren<TextMeshProUGUI>().ToList();
        _Texts.Find(x => x.name == "Name").text = "Guest276";

        TMP_InputField field = NewComment.GetComponentInChildren<TMP_InputField>();
        field.Select();
        field.interactable = false;
    }
}
