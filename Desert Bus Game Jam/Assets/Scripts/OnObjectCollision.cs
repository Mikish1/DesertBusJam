using UnityEngine;

public class OnObjectCollision : MonoBehaviour
{
    [SerializeField] private GameObject newModel;
    [SerializeField] private GameObject brokenModelCopy;

    private void OnCollisionEnter(Collision collision)
    {
        brokenModelCopy = Instantiate(newModel, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(brokenModelCopy, 10f);
    }
}
