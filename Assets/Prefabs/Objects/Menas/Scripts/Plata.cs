using UnityEngine;

public class Plata : MonoBehaviour, IInteractable
{
    public float healAmount = 10f;

    public void Interact(GameObject playerObject)
    {
        Player playerScript = playerObject.GetComponent<Player>();

        if (playerScript != null)
        {
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}