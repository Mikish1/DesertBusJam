using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onGasPickup;
    [SerializeField] private UnityEvent onMotelPickup;
    [SerializeField] private UnityEvent onGasDropOff;
    [SerializeField] private UnityEvent onMotelDropOff;


    public void CheckPickupType(string type, bool pickedUp)
    {
        switch (type) {

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
}
