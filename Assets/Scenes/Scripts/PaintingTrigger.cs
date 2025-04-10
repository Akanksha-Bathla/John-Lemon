using UnityEngine;

public class PaintingTrigger : MonoBehaviour
{
    public RiddleManager riddleManager;

    void Start(){
        riddleManager.CloseRiddle();
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            riddleManager.ShowRiddle();
            // Optional: Destroy this trigger so it doesn't show again
            // Destroy(this.gameObject);
        }
    }
}