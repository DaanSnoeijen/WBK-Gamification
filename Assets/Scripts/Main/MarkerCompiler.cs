using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class MarkerCompiler : MonoBehaviour
{
    [SerializeField] GameObject CompileMarker;

    List<GameObject> _Markers = new List<GameObject>();

    bool isActive;
    bool isShown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Marker")
        {
            _Markers.Add(collision.gameObject);
            collision.GetComponent<Animator>().SetTrigger("Off");
            collision.GetComponent<BoxCollider2D>().enabled = false;

            if (isActive) return;

            CompileMarker.SetActive(true);
            isActive = true;
        }
    }

    public void SwitchMarkerView(bool compile)
    {
        if (compile == isShown) return;

        foreach (GameObject item in _Markers)
        {
            item.GetComponent<Animator>().SetTrigger(compile.ToString());

            isShown = compile;
        }

        CompileMarker.GetComponent<Animator>().SetTrigger((!compile).ToString());
    }
}