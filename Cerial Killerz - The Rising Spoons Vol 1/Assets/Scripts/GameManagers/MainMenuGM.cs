using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuGM : MonoBehaviour
{
    public TestingWin win;
    public Button[] levelButtons;
    public string[] scenes;
    [SerializeField] int currentWinLevel;
    [SerializeField] Button button;
    
    void UpdateButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < currentWinLevel && i < scenes.Length)
                levelButtons[i].interactable = true;
            else
                levelButtons[i].interactable = false;
        }
    }

    private void Start()
    {
        UpdateButtons();
    }

    public void LevelSelect(int number)
    {
        SceneManager.LoadScene(scenes[number]);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
