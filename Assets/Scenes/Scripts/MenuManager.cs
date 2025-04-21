using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    private void Start() {
        instructionsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");  // Replace with your game scene
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Will work in built version
        Application.Quit();
    }
}