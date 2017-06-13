using UnityEngine;
using System.Collections;

public class MacheteHitDetector : MonoBehaviour {
    public int damageAmount = 0;
    private AudioSource source;
    public AudioClip woosh;
    public ParticleSystem hitParticles;
	public AudioSource source2;	


	void Start()
	{
		source = GetComponent<AudioSource>();

	}

    private IEnumerator _power_move() {
		damageAmount = 40;
        yield return new WaitForSeconds(10.0f);
        damageAmount = 20;
        hitParticles.Stop();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            var enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			if (SpiritEnergyManager.Instance.Energy > 20){
				source2.Play();
				hitParticles.Play();
				StartCoroutine(_power_move());
				SpiritEnergyManager.Instance.Energy = 0;
			}

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
