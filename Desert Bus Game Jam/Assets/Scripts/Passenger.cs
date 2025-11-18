using UnityEngine;

public class Passenger : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    Vector3 destinationLocation;
    private float timeRemaining;
    private bool onBus;


    private void Awake()
    {
        onBus = false;
        timeRemaining = 60;
        destinationLocation = destination.transform.position;
    }

    private void Update()
    {
        if (onBus && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void OnBusTrue()
    {
        onBus = true;
    }

    public Vector3 GetDestinationVector()
    {
        return destinationLocation;
    }

}
