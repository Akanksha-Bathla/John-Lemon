using UnityEngine;
using UnityEngine.UI;

public class PuzzleTrigger : MonoBehaviour
{
    public EightTilePuzzleManager eightTilePuzzleManager;
    public Button closeButton; 

    void Start()
    {
        eightTilePuzzleManager.ClosePuzzle();
        if (closeButton != null)
            closeButton.onClick.AddListener(CloseCanvas);
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            eightTilePuzzleManager.ShowPuzzle();
            // Optional: Destroy this trigger so it doesn't show again
            // Destroy(this.gameObject);
        }
        
    }

    private void CloseCanvas()
    {
        eightTilePuzzleManager.ClosePuzzle();
    }
}