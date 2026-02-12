using UnityEngine;

public class StickyScript : MonoBehaviour
{
    private bool isStuck = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if we are already stuck, or if we hit ourselves
        if (isStuck || collision.gameObject == gameObject) return;

        // Stick to the object we hit
        isStuck = true;

        // Make the object a child of the hit object to follow it
        transform.SetParent(collision.transform);

        // Optional: Disable rigidbody to stop physics acting on the stuck object
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}