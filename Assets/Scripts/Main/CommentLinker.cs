using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CommentLinker : MonoBehaviour
{
    [Header("Components to link")]
    [SerializeField] CommentCreator CommentCreator;

    void Start()
    {
        CommentCreator = GetComponentInParent<CommentCreator>();
    }

    public void CreateSubComment() { CommentCreator.CreateSubComment(transform.GetSiblingIndex()); }
}
