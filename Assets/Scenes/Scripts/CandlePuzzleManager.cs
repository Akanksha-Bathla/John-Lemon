using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CandlePuzzleManager : MonoBehaviour
{
    public List<int> correctOrder = new List<int> { 2, 4, 1, 3 }; // Change this to your desired order
    private List<int> playerOrder = new List<int>();
    public List<Button> candles; // Assign 4 candle buttons in the Inspector

    public Sprite litSprite;   // Drag the lit candle sprite here
    public Sprite unlitSprite; // Drag the unlit candle sprite here

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

    private void ResetPuzzle()
    {
        Debug.Log("Wrong order! Try again.");
        playerOrder.Clear();

        foreach (Button candle in candles)
        {
            candle.GetComponent<Image>().sprite = unlitSprite;
        }
    }

    private void PuzzleComplete()
    {
        Debug.Log("Puzzle Solved!");
        // Replace with your actual main scene name or action
        SceneManager.LoadScene("MainScene");
    }
}
