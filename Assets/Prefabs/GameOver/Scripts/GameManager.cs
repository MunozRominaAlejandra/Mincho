using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static bool playerWon = false;

    void Update()
    {
        if (player == null) return;

        if (player.currentHealth <= 0 || player.currentOxygen <= 0)
        {
            playerWon = false;
            SceneManager.LoadScene("Gameover");
        }
    }

    public void Win()
    {
        playerWon = true;
        SceneManager.LoadScene("Gameover");
    }
}