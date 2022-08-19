using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderHandelar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    public UnityAction OnPointerDownEvent;
    public UnityAction<float> OnPointerDragEvent;
    public UnityAction OnPointerUpEvent;

    private Slider UiSlider;

    void Awake()
    {
        UiSlider = GetComponent<Slider>();
        UiSlider.onValueChanged.AddListener(OnSliderValueChange);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnPointerDownEvent != null)
        {
            OnPointerDownEvent.Invoke();
        }
        if (OnPointerDragEvent != null)
        {
            OnPointerDragEvent.Invoke(UiSlider.value);
        }

    }

    public void OnSliderValueChange(float val)
    {
        if (OnPointerDragEvent != null)
        {
            OnPointerDragEvent.Invoke(val);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnPointerUpEvent != null)
        {
            OnPointerUpEvent.Invoke();
        }
        UiSlider.value = 0f;
    }

    private void OnDestroy()
    {
        UiSlider.onValueChanged.RemoveListener(OnSliderValueChange);
    }
}
