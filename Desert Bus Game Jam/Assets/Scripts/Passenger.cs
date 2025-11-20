using UnityEngine;
using UnityEngine.Events;

public class Passenger : MonoBehaviour
{
    [SerializeField] private GameObject destination;
    Vector3 destinationLocation;
    private float timeRemaining;
    private bool onBus;

    private ScoreManager scoreManager;

    [SerializeField] private UnityEvent OnPassengerPickup;



    private void Awake()
    {
        onBus = false;
        timeRemaining = 60;
        destinationLocation = destination.transform.position;
        scoreManager = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
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
        OnPassengerPickup.Invoke();
        onBus = true;
    }

    public Vector3 GetDestinationVector()
    {
        return destinationLocation;
    }

    public void Delivered()
    {
        scoreManager.updateScore(timeRemaining);
        Destroy(gameObject);
    }

}
