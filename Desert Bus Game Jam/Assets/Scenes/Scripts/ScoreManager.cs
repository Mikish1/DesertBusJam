using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private float score = 0;

    private void Start()
    {
        score = 0;
        GetComponent<TextMeshProUGUI>().text = "Score: " + (int)score;
    }

    public void updateScore(float scoreAmount)
    {
        score +=  scoreAmount;
        GetComponent<TextMeshProUGUI>().text = "Score: " + (int)score;
    }
}
