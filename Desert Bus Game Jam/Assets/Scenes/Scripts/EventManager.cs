using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onGasPickup;
    [SerializeField] private UnityEvent onMotelPickup;
    [SerializeField] private UnityEvent onGasDropOff;
    [SerializeField] private UnityEvent onMotelDropOff;
    [SerializeField] private UnityEvent OnAllGasPassengersGone;
    [SerializeField] private UnityEvent OnAllMotelPassengersGone;
    private int totalGasStation;
    private int totalMotel;



    private void Awake()
    {
        totalGasStation = 0;
        totalMotel = 0;

        GameObject busStop = GameObject.Find("BusStop");
        foreach(Transform child in busStop.transform)
        {
            Passenger passenger = child.GetComponent<Passenger>();
            if (passenger.GetDestinationType() == "GasStation")
            {
                totalGasStation++;
            }
            else
                totalMotel++;
        }

    }

    public void CheckPickupType(string passengerType, bool pickedUp)
    {
        switch (passengerType) {

            case "GasStation":
                if (pickedUp) { onGasPickup?.Invoke(); }
                else { onGasDropOff?.Invoke(); }
                break;

            case "Motel":
                if (pickedUp) { onMotelPickup?.Invoke(); }
                else { onMotelDropOff?.Invoke(); }

                    break;

            default: break;
        }
    }

    public void decreaseTotalCount(string passengerType)
    {
        switch (passengerType)
        {

            case "GasStation":
                totalGasStation -= 1;
                if (totalGasStation == 0) { OnAllGasPassengersGone?.Invoke(); }
                break;

            case "Motel":
                totalMotel -= 1;
                if (totalMotel == 0) { OnAllMotelPassengersGone?.Invoke(); }
                break;

            default: break;
        }
    }
}
