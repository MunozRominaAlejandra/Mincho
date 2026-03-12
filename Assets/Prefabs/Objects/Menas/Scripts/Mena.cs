using UnityEngine;

public class Mena : MonoBehaviour, IInteractable
{
    public GameObject pickupPrefab;

    public void Interact(GameObject Player)
    {
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
