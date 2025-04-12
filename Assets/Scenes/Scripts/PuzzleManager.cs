using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public static int puzzlesSolvedCount = 0;
    public int totalPuzzles = 3;
    public Image[] starImages;             // These will be reassigned each scene
    public Sprite filledStarSprite;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;  // Listen to scene load
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // Unsubscribe to avoid memory leaks
    }

    // Re-fetch star images whenever a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        starImages = GameObject.Find("ProgressTracker")?.GetComponentsInChildren<Image>();

        // Refill stars if needed
        for (int i = 0; i < puzzlesSolvedCount && i < starImages.Length; i++)
        {
            if (starImages[i] != null)
                starImages[i].sprite = filledStarSprite;
        }
    }

    public void PuzzleSolved()
    {
        if (puzzlesSolvedCount < totalPuzzles && starImages.Length > puzzlesSolvedCount && starImages[puzzlesSolvedCount] != null)
        {
            starImages[puzzlesSolvedCount].sprite = filledStarSprite;
            puzzlesSolvedCount++;
            Debug.Log("Puzzle solved! Total puzzles solved: " + puzzlesSolvedCount);
        }
    }

    public bool AllPuzzlesSolved()
    {
        return puzzlesSolvedCount >= totalPuzzles;
    }
}