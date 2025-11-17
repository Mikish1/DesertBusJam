using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider backLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider backRightWheel;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    [SerializeField] private float acceleration = 500f;
    [SerializeField] private float breakingForce = 300f;
    [SerializeField] private float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;


    private void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBrakeForce = breakingForce;

        else currentBrakeForce = 0f;

        // Apply acceleration to front wheels
        frontRightWheel.motorTorque  = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;

        // Apply braking force to all wheels
        frontRightWheel.brakeTorque = currentBrakeForce;
        frontLeftWheel.brakeTorque = currentBrakeForce;
        backRightWheel.brakeTorque = currentBrakeForce;
        backLeftWheel.brakeTorque = currentBrakeForce;

        // Steering angle
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;

        //Update w
        //UpdateWheel(frontLeftWheel, frontLeftWheelTransform);
        //UpdateWheel(backLeftWheel, backLeftWheelTransform);
        //UpdateWheel(frontRightWheel, frontRightWheelTransform);
        //UpdateWheel(backRightWheel, backRightWheelTransform);
    }

    void UpdateWheel(WheelCollider col, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        // Set wheel transform state
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

}
