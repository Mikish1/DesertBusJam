using System.Collections.Generic;
using UnityEngine;

public class passengerDropOff : MonoBehaviour
{

    private PlayerBusController playerBus;
    private List<GameObject> passengers;
    private float maxBusMagnitude = 0.003f;

    private void OnTriggerEnter(Collider other)
    {
        playerBus = other.gameObject.GetComponentInParent<PlayerBusController>();
        passengers = playerBus.getListOfPassengers();
    }

    private void OnTriggerStay(Collider other)
    {
        float busMagnitude = Mathf.Abs(playerBus.busVelocity());

        // Check if player is moving too fast
        if (busMagnitude > maxBusMagnitude)
        {
            return;
        }

        for (int i = 0; i < passengers.Count; i++)
        {
            GameObject passenger = passengers[i];
            Passenger passengerScript = passenger.GetComponent<Passenger>();
            Vector3 passengerDestinationVector = passengerScript.GetDestinationVector();

            // Check passengers distance from desired destination
            float distanceFromDestination = Vector3.Distance(this.transform.position, passengerDestinationVector);

            // Remove passenger if at destination
            if (distanceFromDestination < 5)
            {
                passengers.RemoveAt(i);
                Destroy(passenger);
            }
        }

        
    }
}
