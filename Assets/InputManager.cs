using UnityEngine; // Required for MonoBehaviour and Input class functionality
using UnityEngine.Events; // Allows the use of UnityEvent, which is used for custom event handling

// This class manages player input and broadcasts events based on specific input actions
public class InputManager : MonoBehaviour
{
    // UnityEvent that triggers when a movement-related input is detected
    // It passes a Vector2 as the parameter to indicate the direction of movement
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();

    // UnityEvent that triggers when the Space key is pressed
    public UnityEvent OnSpacePressed = new UnityEvent();

    // Unity's Update method is called once per frame
    // It is used here to check for player input and handle it accordingly
    private void Update()
    {
        // Check if the Space key is pressed down during this frame
        if (Input.GetKeyDown(KeyCode.Space)) // Input.GetKeyDown returns true only on the frame the key is pressed
        {
            // Invoke the OnSpacePressed UnityEvent to notify any listeners that the Space key was pressed
            OnSpacePressed?.Invoke(); // The null-conditional operator ensures it only invokes if there are subscribers
        }

        // Initialize a Vector2 variable to track movement input
        // Vector2.zero represents a (0, 0) vector, which is the default value
        Vector2 input = Vector2.zero;

        // Check if the A key is being held down
        // Input.GetKey returns true as long as the key is held
        if (Input.GetKey(KeyCode.A)) // A key typically moves a player or object left in 2D/3D games
        {
            // Add Vector2.left (-1, 0) to the input vector to indicate leftward movement
            input += Vector2.left; // This modifies the input variable to include leftward movement
        }

        // Check if the D key is being held down
        // D key typically moves a player or object right in 2D/3D games
        if (Input.GetKey(KeyCode.D))
        {
            // Add Vector2.right (1, 0) to the input vector to indicate rightward movement
            input += Vector2.right; // This modifies the input variable to include rightward movement
        }

        // Invoke the OnMove UnityEvent with the calculated input vector
        // This notifies any listeners about the current movement direction
        OnMove?.Invoke(input); // The null-conditional operator ensures it only invokes if there are subscribers
    }
}
