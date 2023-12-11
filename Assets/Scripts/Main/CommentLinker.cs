using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CommentLinker : MonoBehaviour
{
    CommentCreator CommentCreator;

    void Start()
    {
        CommentCreator = GetComponentInParent<CommentCreator>();
    }

    public void CreateSubComment() { CommentCreator.CreateSubComment(transform.GetSiblingIndex()); }
}
