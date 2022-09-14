using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        UpdatePlayerNameText();
        UpdateScoreText();
    }

    public void PlayerNameChanged(string playerName)
    {
        GameMemory.Instance.PlayerName = playerName;
        this.UpdatePlayerNameText();
    }
 
    private void UpdateScoreText()
    {
        scoreText.text = "Best score: "+ GameMemory.Instance.BestPlayerScore;
    }
    public void UpdatePlayerNameText()
    {
        GameObject ifgo = GameObject.Find("NameField"); 
        TMP_InputField ifif = ifgo.GetComponent<TMP_InputField>(); 
        ifif.text = GameMemory.Instance.PlayerName;
    }

    public void StartNewGame() { 
        SceneManager.LoadScene(1);
    }
    public void ExitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
