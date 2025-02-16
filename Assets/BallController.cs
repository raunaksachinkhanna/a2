using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ballRB;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    private bool isBallLaunched;
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
        
    }
    private void LaunchBall(){
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
            }
    // Update is called once per frame
    void Update()
    {
        
    }
}