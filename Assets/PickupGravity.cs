using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGravity : MonoBehaviour
{
    [field: SerializeField] public float GravitySpeed { get; private set; }

    private List<ResoucePickUp> _nearbyResources = new();

    private void FixedUpdate()
    {
        foreach (ResoucePickUp pickup in _nearbyResources)
        {
            Vector2 directionToCenter = (transform.position - pickup.transform.position).normalized;

            pickup.transform.Translate(directionToCenter * GravitySpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResoucePickUp pickup = collision.gameObject.GetComponent<ResoucePickUp>();

        if (pickup)
        {
            _nearbyResources.Add(pickup);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ResoucePickUp pickup = collision.gameObject.GetComponent<ResoucePickUp>();

        if (pickup)
        {
            _nearbyResources.Remove(pickup);
        }
    }
}
