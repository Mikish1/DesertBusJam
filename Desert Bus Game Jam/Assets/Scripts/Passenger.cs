using UnityEngine;

public class Passenger : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    Vector3 destinationLocation;
    private float timeOnBus;
    private bool onBus;


    private void Awake()
    {
        onBus = false;
        destinationLocation = destination.transform.position;
        Debug.Log(destinationLocation.ToString());
    }

    private void Update()
    {
        if (onBus)
        {
            timeOnBus += Time.deltaTime;
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
