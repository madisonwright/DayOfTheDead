using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour {
    public float speed = 1.0f;
    public AudioSource source3;
    public AudioSource source4;
    private float x;


    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var newPosition = transform.position;
		newPosition += new Vector3(horizontal, 0.0f, vertical).normalized * speed * Time.deltaTime;
		//newPosition.x = Mathf.Clamp (newPosition.x, -50.0f, 50.0f);
		//newPosition.z = Mathf.Clamp (newPosition.z, -50.0f, 50.0f);
        //newPosition.y = Mathf.Clamp (newPosition.y, 0.0f, 0.0f);

		transform.position = newPosition;

        Turn();

        if(Input.GetMouseButton(0)) {
            animator.SetTrigger("Attacking");
            x = Random.Range(0, 2);
            if (x < 1){
                source3.Play();
            } else{
                source4.Play();
            }
        }
    }

    private void Turn() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;
        if (Physics.Raycast(camRay, out mouseHit)) {

            Vector3 playerToMouse = mouseHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotatation;
        }
    }
}
