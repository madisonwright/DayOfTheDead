using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour {
    public float speed = 1.0f;

    private void Update() {
        var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        var vertical = CrossPlatformInputManager.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
    }
}
