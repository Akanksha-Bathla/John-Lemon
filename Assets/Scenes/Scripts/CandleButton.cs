using UnityEngine;
using UnityEngine.UI;

public class CandleButton : MonoBehaviour
{
    public int candleNumber;
    public CandlePuzzleManager puzzleManager;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        puzzleManager.OnCandleClicked(candleNumber);
    }
}
