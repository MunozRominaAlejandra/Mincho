using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        if (GameManager.playerWon)
        {
            winPanel.SetActive(true);
            losePanel.SetActive(false);
        }
        else
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}