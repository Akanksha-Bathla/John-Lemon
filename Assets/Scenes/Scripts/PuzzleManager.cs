using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public bool[] puzzlesSolved = new bool[3]; // 3 puzzles
    public Image[] starImages; // Assign 3 star UI images
    public Sprite filledStarSprite; // Assign the filled star image in Inspector
    public int NoOfPuzzlesSolved;

    public void SolvePuzzle(int index)
    {
        if (!puzzlesSolved[index])
        {
            puzzlesSolved[index] = true;
            starImages[index].sprite = filledStarSprite; // Change to filled star
        }
    }

    public bool AllPuzzlesSolved()
    {
        foreach (bool solved in puzzlesSolved)
        {
            if (!solved) return false;
        }
        return true;
    }
}