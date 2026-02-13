using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerController player1;
    public PlayerController player2;
    
    [Header("Panels")]
    public Canvas WinP1;
    public Canvas WinP2;
    public Canvas StartPanel;
    public Canvas PreparePanel;

    [Header("CanRun")]
    public bool canRun = false;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    
    void Start()
    {
        player1.onFinishP1.AddListener(FinishGameP1);
        player2.onFinishP2.AddListener(FinishGameP2);
        
        WinP1.enabled = false;
        WinP2.enabled = false;
        StartPanel.enabled = false;
        PreparePanel.enabled = true;
        StartCoroutine(StartGame());
    }
    
    public void FinishGameP1()
    {
        WinP1.enabled = true;
    }
    
    public void FinishGameP2()
    {
        WinP2.enabled = true;
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4f);
        PreparePanel.enabled = false;
        StartPanel.enabled = true;
        StartCoroutine(StartPanelQuit());
    }
    
    public IEnumerator StartPanelQuit()
    {
        yield return new WaitForSeconds(0.5f);
        StartPanel.enabled = false;
        canRun = true;
    }
}
