using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EightTilePuzzleManager : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public List<Button> tiles; // Assign in inspector (9 buttons in order)
    public GameObject puzzlePanel;
    private bool Solved = false; // checking if it is already solved or not.

    private int emptyTileIndex;

    void Start()
    {
        ShuffleTiles();
        AssignTileClicks();
        UpdateEmptyTileIndex();
    }

    bool IsSolvable(List<int> numbers)
    {
        int invCount = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                if (numbers[i] > numbers[j] && numbers[i] != 0 && numbers[j] != 0)
                    invCount++;
            }
        }
        return invCount % 2 == 0;
    }

    void ShuffleTiles()
    {
        List<int> numbers = new List<int>();

        do
        {
            numbers.Clear(); // 🔁 Make sure no duplicates
            for (int i = 1; i <= 8; i++) numbers.Add(i);
            numbers.Add(0); // 0 = empty

            // Fisher-Yates Shuffle
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }

        } while (!IsSolvable(numbers)); // ♻ Retry until solvable

        // Apply shuffled numbers to tiles
        for (int i = 0; i < tiles.Count; i++)
        {
            var text = tiles[i].GetComponentInChildren<TextMeshProUGUI>();
            if (numbers[i] == 0)
                text.text = "";
            else
                text.text = numbers[i].ToString();
        }
    }

    void AssignTileClicks()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            int index = i;
            tiles[i].onClick.AddListener(() => OnTileClick(index));
        }
    }

    void UpdateEmptyTileIndex()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            var text = tiles[i].GetComponentInChildren<TextMeshProUGUI>();
            if (text.text == "")
            {
                emptyTileIndex = i;
                return;
            }
        }
    }

    void OnTileClick(int clickedIndex)
    {
        if (IsAdjacent(clickedIndex, emptyTileIndex))
        {
            SwapTiles(clickedIndex, emptyTileIndex);
            UpdateEmptyTileIndex();

            if (IsSolved())
            {
                Debug.Log("Puzzle Solved!");
                if(!Solved){
                    puzzleManager.PuzzleSolved(); // ✅ Notify manager
                    Solved = true;
                }
                ClosePuzzle();
            }
        }
    }

    bool IsAdjacent(int index1, int index2)
    {
        int row1 = index1 / 3;
        int col1 = index1 % 3;
        int row2 = index2 / 3;
        int col2 = index2 % 3;
        return (Mathf.Abs(row1 - row2) + Mathf.Abs(col1 - col2)) == 1;
    }

    void SwapTiles(int a, int b)
    {
        var textA = tiles[a].GetComponentInChildren<TextMeshProUGUI>();
        var textB = tiles[b].GetComponentInChildren<TextMeshProUGUI>();

        string temp = textA.text;
        textA.text = textB.text;
        textB.text = temp;
    }

    bool IsSolved()
    {
        for (int i = 0; i < 8; i++)
        {
            var text = tiles[i].GetComponentInChildren<TextMeshProUGUI>();
            if (text.text != (i + 1).ToString())
                return false;
        }

        var lastText = tiles[8].GetComponentInChildren<TextMeshProUGUI>();
        return lastText.text == "";
    }

    public void ShowPuzzle()
    {
        puzzlePanel.SetActive(true);
    }

    public void ClosePuzzle()
    {
        puzzlePanel.SetActive(false);
    }
}