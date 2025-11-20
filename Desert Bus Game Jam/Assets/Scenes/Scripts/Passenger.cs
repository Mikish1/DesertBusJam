using UnityEngine;
using UnityEngine.Events;

public class Passenger : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    [SerializeField] private string destinationType;
    Vector3 destinationLocation;
    private float timeRemaining;
    private bool onBus;

    private ScoreManager scoreManager;
    private EventManager eventManager;



    private void Awake()
    {
        onBus = false;
        timeRemaining = 60;
        destinationLocation = destination.transform.position;
        scoreManager = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
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
        eventManager.CheckPickupType(destinationType, true);
        onBus = true;
    }

    public Vector3 GetDestinationVector()
    {
        return destinationLocation;
    }

    public void Delivered()
    {
        eventManager.CheckPickupType(destinationType, false);
        scoreManager.updateScore(timeRemaining);
        Destroy(gameObject);
    }

}
