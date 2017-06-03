using UnityEngine;

public class MacheteHitDetector : MonoBehaviour {
    public int damageAmount = 0;
    private AudioSource source;
    public AudioClip woosh;
    
	void Start()
	{
		source = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			if (!enemyHealth) {
				var starEnemyHealth = other.gameObject.GetComponent<StarEnemyHealth> ();
				source.PlayOneShot (woosh);
				starEnemyHealth.TakeDamage (damageAmount);

			} else {
				source.PlayOneShot (woosh);
				enemyHealth.TakeDamage (damageAmount);
			}
        }
    }
}
