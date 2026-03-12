using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    public float interactDistance = 2f;
    public LayerMask interactLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    void Interact()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, interactDistance, interactLayer);

        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }
    }
}