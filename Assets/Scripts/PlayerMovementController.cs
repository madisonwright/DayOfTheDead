using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour {
    public float speed = 1.0f;

    private void Update() {
        var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        var vertical = CrossPlatformInputManager.GetAxis("Vertical");

		var newPosition = transform.position;
		newPosition += new Vector3(horizontal, 0.0f, vertical).normalized * speed * Time.deltaTime;
		newPosition.x = Mathf.Clamp (newPosition.x, -50.0f, 50.0f);
		newPosition.z = Mathf.Clamp (newPosition.z, -50.0f, 50.0f);
		transform.position = newPosition;
    }
}
