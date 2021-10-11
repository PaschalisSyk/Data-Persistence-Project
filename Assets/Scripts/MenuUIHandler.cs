using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public string bestScoreName;
    public string bestScore;
    public TMP_InputField nameField;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        ScoreManager.instance.LoadData();

        if (ScoreManager.instance.activePlayerName.Length > 0)
        {
            nameField.text = ScoreManager.instance.activePlayerName;
        }

        if (ScoreManager.instance.heighScore > 0)
        {
            scoreText.text = $"{ScoreManager.instance.heighScoreName} : {ScoreManager.instance.heighScore}";
        }
        else
        {
            scoreText.text = "No High Score Yet";
        }
    }

    public void ApplyName()
    {
        ScoreManager.instance.activePlayerName = nameField.text;
    }

    public void StartGame()
    {

        SceneManager.LoadScene(1);
        ApplyName();
    }

    public void QuitGame()
    {
        ScoreManager.instance.SaveDate();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
