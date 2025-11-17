using Unity.VisualScripting;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Transform wheelTransform;
    [SerializeField] private bool wheelTurn;

    void Update()
    {
        //if (wheelTurn)
        //{
        //    wheelTransform.localEulerAngles = new Vector3(wheelTransform.localEulerAngles.x, wheelCollider.steerAngle = wheelTransform.localEulerAngles.z, wheelTransform.localEulerAngles.z);
        //}
        wheelTransform.Rotate(wheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
