using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBusController : MonoBehaviour
{
    [SerializeField] private int maxPassengers = 10;
    [SerializeField] private Rigidbody rb;
    private List<GameObject> passengers;
    private int currentPassengers;


    private void Awake()
    {
        currentPassengers = 0;
        passengers = new List<GameObject>();
    }

    public float busVelocity()
    {
        return rb.angularVelocity.magnitude;
    }

    public void getPassengers(GameObject passenger)
    {
        passengers.Add(passenger);
        passenger.transform.parent = this.transform;

        // Start timer for passenger
        Passenger passengerControl = passenger.GetComponent<Passenger>();
        passengerControl.OnBusTrue();

        currentPassengers++;
    }

    public bool isBusFull()
    {
        return currentPassengers < maxPassengers;
    }

    public List<GameObject> getListOfPassengers()
    {
        return passengers;
    }
}
