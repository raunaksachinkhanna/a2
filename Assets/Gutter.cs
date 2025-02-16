using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // Get the Rigidbody component from the object that entered the trigger
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
            // Store the velocity magnitude before resetting the velocity
            float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

            // Reset the linear and angular velocity to zero
            ballRigidBody.linearVelocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;

            // Add force in the forward direction of the gutter
            // Use the cached velocity magnitude to maintain some realism
            ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
        
    }
}
