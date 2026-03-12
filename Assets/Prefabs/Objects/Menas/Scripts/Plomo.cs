using UnityEngine;

public class Plomo : MonoBehaviour, IInteractable
{
    public float oxygenAmount = 20f;

    public void Interact(GameObject playerObject)
    {
        Player playerScript = playerObject.GetComponent<Player>();

        if (playerScript != null)
        {
            playerScript.AddOxygen(oxygenAmount);
            Destroy(gameObject);
        }
    }
}