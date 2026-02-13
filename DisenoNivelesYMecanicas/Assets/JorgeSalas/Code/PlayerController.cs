using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Key")]
    public KeyCode playerRun;
    
    [Header("Slider")]
    public Slider slider;
    private int maxSliderValue = 100;
    
    [Header("Events")]
    public UnityEvent onFinishP1;
    public UnityEvent onFinishP2;

    [Header("Player number")]
    public bool player1 = false;
    
    void Start()
    {
        slider.value = 0;
        if (onFinishP1 == null) onFinishP1 = new UnityEvent();
        if (onFinishP2 == null) onFinishP2 = new UnityEvent();
        slider.maxValue = maxSliderValue;
    }

    void Update()
    {
        if (GameManager.Instance.canRun == true)
            ButtonPressed();
    }

    public void ButtonPressed()
    {
        if (Input.GetKeyDown(playerRun))
        {
            slider.value += 1;
            if (slider.value == maxSliderValue && player1 == false)
                onFinishP2?.Invoke();
            else if (slider.value == maxSliderValue && player1 == true)
                onFinishP1?.Invoke();
        }
    }
}
