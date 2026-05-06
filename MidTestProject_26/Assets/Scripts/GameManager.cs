using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button gameStartButton;

    private void Start()
    {
        gameStartButton.onClick.AddListener(OnGameStartButtonClicked);

    }

    private void OnGameStartButtonClicked()
    {
        string playerName = inputField.text.Trim();
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Player name cannot be empty.");
            return;
        }
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("Player Name saved: " + playerName);

        SceneManager.LoadScene("Level_1");
    }

}
