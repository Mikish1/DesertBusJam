using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    [SerializeField] private List<GameObject> passengers;
    private PlayerBusController playerBus;
    private float maxBusMagnitude = 0.003f;


    private void OnTriggerStay(Collider other)
    {
        playerBus = other.gameObject.GetComponentInParent<PlayerBusController>();
        float busMagnitude = Mathf.Abs(playerBus.busVelocity());


        // Check if player is moving too fast
        if (busMagnitude > maxBusMagnitude)
        {
            return;
        }
        
        // Check if there are any passengers to pick up and if the bus is full
        if (passengers.Count > 0 && playerBus.isBusFull())
        {
            Debug.Log("pick up");

            // Transger passenger from bus stop to the bus
            GameObject passenger = passengers[0];
            passengers.RemoveAt(0);
            playerBus.getPassengers(passenger);
        }
    }

}
