using UnityEngine;
using UnityEngine.UI;

public class CandleCode : MonoBehaviour
{
    public Canvas candleCanvas; // The canvas to show
    public Button closeButton;  // Reference to the close (X) button
    public string playerTag = "Player";

    private void Start()
    {
        if (candleCanvas != null)
            candleCanvas.enabled = false;

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseCanvas);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (candleCanvas != null)
                candleCanvas.enabled = true;
        }
    }

    private void CloseCanvas()
    {
        if (candleCanvas != null)
            candleCanvas.enabled = false;
    }
}