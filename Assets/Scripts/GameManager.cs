using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject mainMenuPanel;
    public GameObject creditPanel;
    
    public Button startButton;
    public Button creditButton;
    public Button backButton;
    public Button quitButton;
    
    private void Awake()
    {
        // (ถ้ามี Instance อยู่แล้วให้ทำลายตัวใหม่)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        creditButton.onClick.AddListener(Credit);
        backButton.onClick.AddListener(MainMenu);
        quitButton.onClick.AddListener(Quit);
    }

    public void MainMenu()
    {
        mainMenuPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
    }
    
    public void Credit()
    {
        mainMenuPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}