using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform player;

    private Vector3 offset;

    private void Start() {
        offset = transform.position - player.position;
    }

    private void LateUpdate() {
        var newPosition = player.position + offset;
        newPosition.x = Mathf.Clamp (newPosition.x, 25.0f, 175.0f);
        transform.position = newPosition;

    }
}
