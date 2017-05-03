using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform player;

    private Vector3 offset;

    private void Start() {
        offset = transform.position - player.position;
    }

    private void LateUpdate() {
        transform.position = player.position + offset;
    }
}
