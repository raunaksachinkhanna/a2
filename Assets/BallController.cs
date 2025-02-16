using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ballRB;
    [SerializeField] private Transform ballAnchor;
    private bool isBallLaunched = false;
    [SerializeField] private float force = 20f; // Increased default force
    [SerializeField] private InputManager inputManager;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        
        if (inputManager == null)
        {
            Debug.LogError("InputManager not assigned in the Inspector!");
            return;
        }

        inputManager.OnSpacePressed.AddListener(LaunchBall);

        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;

        isBallLaunched = true;
        transform.parent = null; // Detach from anchor
        ballRB.isKinematic = false;

        // Log direction and apply force
        Debug.Log($"Ball forward direction: {transform.forward}");
        ballRB.AddForce(transform.forward * force, ForceMode.VelocityChange); // Use VelocityChange
        Debug.Log("Ball launched!");
    }
}
