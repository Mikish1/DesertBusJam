using UnityEngine;

public class OnObjectCollision : MonoBehaviour
{
    [SerializeField] private GameObject newModel;
    private GameObject brokenModelCopy;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        brokenModelCopy = Instantiate(newModel, transform.position, transform.rotation);
        Destroy(brokenModelCopy, 10f);
    }
}
