using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RiddleManager : MonoBehaviour
{
    public PuzzleManager puzzleManager; // Assign via Inspector
    public GameObject riddlePanel;
    public TMP_Text riddleText;
    public TMP_InputField answerInput;
    public TMP_Text feedbackText;

    private string correctAnswer = "keyboard";
    private bool solved = false;

    public void ShowRiddle()
    {
        riddlePanel.SetActive(true);
        riddleText.text = "I have keys but open no locks, I have space but no room, I let you enter but not go outside. What am I?";
        feedbackText.text = "";
        answerInput.text = "";
    }

    public void SubmitAnswer()
    {
        string userAnswer = answerInput.text.Trim().ToLower();

        if (userAnswer == correctAnswer)
        {
            feedbackText.text = "Correct!";
            feedbackText.color = Color.green;
            // You can add: scoreManager.AddPoint(); or similar
            if(!solved){
                puzzleManager.PuzzleSolved(); // 0 for the first puzzle
                solved = true;
            }
            CloseRiddle(); // Optional
        }
        else
        {
            feedbackText.text = "Try again!";
            feedbackText.color = Color.red;
        }
    }

    public void CloseRiddle()
    {
        riddlePanel.SetActive(false);
    }
}