using System.Collections;
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
    public int changeNum = 1;
    
    [Header("Events")]
    public UnityEvent onFinishP1;
    public UnityEvent onFinishP2;

    [Header("Player number")]
    public bool player1 = false;
    
    [Header("List")]
    private int[] options = {25, 50, 75};
    [SerializeField] private int index;
    [SerializeField] private int result;
    
    void Start()
    {
        slider.value = 0;
        if (onFinishP1 == null) onFinishP1 = new UnityEvent();
        if (onFinishP2 == null) onFinishP2 = new UnityEvent();
        slider.maxValue = maxSliderValue;
        index = Random.Range(0, options.Length);
        result = options[index];
    }

    void Update()
    {
        if (GameManager.Instance.canRun == true) ButtonPressed();
        ChangeSliderMaxValue();
    }

    public void ButtonPressed()
    {
        if (Input.GetKeyDown(playerRun))
        {
            slider.value += changeNum;
            if (slider.value == maxSliderValue && player1 == false)
                onFinishP2?.Invoke();
            else if (slider.value == maxSliderValue && player1 == true)
                onFinishP1?.Invoke();
        }
    }

    public void ChangeSliderMaxValue()
    {
        if (slider.value == result && player1 == false)
            StartCoroutine(ChangeValueClicks());
        else if (slider.value == result && player1 == true)
            StartCoroutine(ChangeValueClicks());
    }
    
    public IEnumerator ChangeValueClicks()
    {
        changeNum = 2;
        yield return new WaitForSeconds(1.5f);
        changeNum = 1;
    }
}
