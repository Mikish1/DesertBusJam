using TMPro;
using UnityEngine;

public class DestinationCounter : MonoBehaviour
{
    private float passengerCount = 0;

    private void Start()
    {
        passengerCount = 0;
        GetComponent<TextMeshProUGUI>().text = passengerCount.ToString();
    }

    public void IncreaseCounter()
    {
        passengerCount += 1;
        GetComponent<TextMeshProUGUI>().text = passengerCount.ToString();
    }

    public void DecreaseCounter()
    {
        passengerCount -= 1;
        GetComponent<TextMeshProUGUI>().text = passengerCount.ToString();
    }
}
