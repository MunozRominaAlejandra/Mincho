using UnityEngine;

public class GasZone : MonoBehaviour
{
    public float drainMultiplier = 4f;

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();

        if (player != null)
        {
            player.SetOxygenDrainMultiplier(drainMultiplier);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();

        if (player != null)
        {
            player.SetOxygenDrainMultiplier(1f);
        }
    }
}