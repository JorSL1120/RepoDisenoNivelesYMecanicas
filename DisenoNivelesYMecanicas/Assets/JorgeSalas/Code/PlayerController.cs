using System.Collections;
using TMPro;
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

    [Header("Buff")]
    public float timeToBuff = 6.5f;
    public Canvas buffCanvasP1;
    public Canvas buffCanvasP2;
    private int buffPosition = 50;
    private float contToBuff = 0;
    
    [Header("Text Cont")]
    public TextMeshProUGUI timerText;
    
    void Start()
    {
        slider.value = 0;
        if (onFinishP1 == null) onFinishP1 = new UnityEvent();
        if (onFinishP2 == null) onFinishP2 = new UnityEvent();
        slider.maxValue = maxSliderValue;
        contToBuff = 0;
        buffCanvasP1.enabled = false;
        buffCanvasP2.enabled = false;
    }

    void Update()
    {
        if (GameManager.Instance.canRun == true)
        {
            contToBuff += Time.deltaTime;
            Debug.Log(contToBuff);
            if(timerText != null) timerText.text = contToBuff.ToString("F2");
            ButtonPressed();
        }
        
        ChangeNumValue();
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

    public void ChangeNumValue()
    {
        if ((slider.value == buffPosition && contToBuff <= timeToBuff) && player1 == false)
        {
            StartCoroutine(ChangeValueClicks());
            buffCanvasP2.enabled = true;
        }
        else if ((slider.value == buffPosition && contToBuff <= timeToBuff) && player1 == true)
        {
            StartCoroutine(ChangeValueClicks());
            buffCanvasP1.enabled = true;
        }
    }
    
    public IEnumerator ChangeValueClicks()
    {
        changeNum = 2;
        yield return new WaitForSeconds(1.5f);
        changeNum = 1;
        buffCanvasP2.enabled = false;
        buffCanvasP1.enabled = false;
    }
}
