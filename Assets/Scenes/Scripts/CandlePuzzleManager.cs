using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CandlePuzzleManager : MonoBehaviour
{
    public List<int> correctOrder = new List<int> { 2, 4, 1, 3 }; // Set desired order here
    private List<int> playerOrder = new List<int>();
    public List<Button> candles; // Assign 4 candle buttons in the Inspector

    public Sprite litSprite;   // Assign lit sprite
    public Sprite unlitSprite; // Assign unlit sprite

    public Button closeButton; // <-- Add this

    void Start()
    {
        if (closeButton != null)
            closeButton.onClick.AddListener(ClosePuzzleScene);
    }


    public void OnCandleClicked(int candleNumber)
    {
        if (playerOrder.Count < correctOrder.Count)
        {
            playerOrder.Add(candleNumber);
            candles[candleNumber - 1].GetComponent<Image>().sprite = litSprite;

            if (playerOrder.Count == correctOrder.Count)
            {
                CheckOrder();
            }
        }
    }

    private void CheckOrder()
    {
        for (int i = 0; i < correctOrder.Count; i++)
        {
            if (playerOrder[i] != correctOrder[i])
            {
                ResetPuzzle();
                return;
            }
        }

        PuzzleComplete();
    }

    // private void ResetPuzzle()
    // {
    //     Debug.Log("Wrong order! Try again.");
    //     playerOrder.Clear();

    //     foreach (Button candle in candles)
    //     {
    //         candle.GetComponent<Image>().sprite = unlitSprite;
    //     }
    // }

    private void ResetPuzzle()
    {
        Debug.Log("Wrong order! Try again.");
        playerOrder.Clear();

        foreach (Button candle in candles)
        {
            // Check if the Image component is not null
            Image candleImage = candle.GetComponent<Image>();
            if (candleImage != null) // Ensure it's not destroyed or missing
            {
                candleImage.sprite = unlitSprite;
            }
            else
            {
                Debug.LogWarning("Candle Image component is missing or destroyed.");
            }
        }
    }

    private void PuzzleComplete()
    {
        Debug.Log("Puzzle Solved!");

        // Call PuzzleSolved from the PuzzleManager singleton

        if (PuzzleManager.Instance != null)
        {
            Debug.Log("if");
            PuzzleManager.Instance.PuzzleSolved();
        }
        else
        {
            Debug.Log("else");
        }
        Debug.Log("Main Scene loading");
        // Now safely load the main scene
        SceneManager.LoadScene("MainScene");
    }
    
    private void ClosePuzzleScene() // <-- Add this
    {
        Debug.Log("Close button clicked - Returning to MainScene");
        SceneManager.LoadScene("MainScene");
    }
}