using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Variables
    public float damageAmount = 5f;
    public float damageTickRate = 0.5f;

    private Player playerInZone;
    private float nextDamageTime;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (playerInZone != null && Time.time >= nextDamageTime)
        {
            playerInZone.TakeDamage(damageAmount);
            nextDamageTime = Time.time + damageTickRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            playerInZone = player;
            player.TakeDamage(damageAmount);
            nextDamageTime = Time.time + damageTickRate;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            playerInZone = null;
        }
    }
    #endregion
}