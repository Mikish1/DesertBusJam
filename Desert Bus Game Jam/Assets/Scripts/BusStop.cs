using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour
{
    [SerializeField] private List<GameObject> passengers;
    private PlayerBusController playerBus;
    private float maxBusMagnitude = 0.003f;
    private float timer = 0;


    private void OnTriggerExit(Collider other)
    {
        //reset timer when exiting zone
        timer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        playerBus = other.gameObject.GetComponentInParent<PlayerBusController>();
        float busMagnitude = Mathf.Abs(playerBus.busVelocity());
        timer += Time.deltaTime;


        // Check if player is moving too fast
        if (busMagnitude > maxBusMagnitude)
        {
            timer = 0;
            return;
        }
        
        // Check if there are any passengers to pick up and if the bus is full
        if (passengers.Count > 0 && playerBus.isBusFull() && timer >= 1)
        {
            Debug.Log("pick up");

            // Transger passenger from bus stop to the bus
            GameObject passenger = passengers[0];
            passengers.RemoveAt(0);
            playerBus.getPassengers(passenger);
            timer = 0;
        }
    }

}
