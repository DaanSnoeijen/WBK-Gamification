using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircleSliderLogic : MonoBehaviour
{
    [Header("Slider items that move on touch")]
    [SerializeField] GameObject HandleArea;
    [SerializeField] Slider Slider;
    [SerializeField] Animator ButtonAnimator;

    [Header("Text in slider")]
    [SerializeField] TextMeshProUGUI Text;

    CircleSliderContentLinker Linker;

    bool pressed;
    bool continued;

    int maxSliderValue;

    private void Start()
    {
        Linker = GetComponentInParent<CircleSliderContentLinker>();
        maxSliderValue = Linker.GetMaxValue();
    }

    private void Update()
    {
        if (pressed)
        {
            Vector2 thisPosition = new Vector2(transform.position.x * (Screen.currentResolution.width / 100) + Screen.currentResolution.width / 2 + 150, 
                transform.position.y * (Screen.currentResolution.height / 10) + Screen.currentResolution.height / 2 + 100);
            float angle = CalculateAngle(thisPosition, Input.mousePosition);

            HandleArea.transform.eulerAngles = new Vector3(0, 0, angle);
            Slider.value = 360 - angle;

            Text.text = CalculateInputNumber(maxSliderValue);
        }
    }

    string CalculateInputNumber(int maxValue) { return Mathf.Round(maxValue * (Slider.value / 360f)).ToString(); }

    float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }

    public void ButtonDown() 
    { 
        pressed = true;
        ButtonAnimator.SetTrigger("Tap");
    }

    public void ButtonUp() 
    { 
        pressed = false;
        ButtonAnimator.SetTrigger("Release");
        if (!continued) Linker.NextMessage();
        continued = true;
    }
}
