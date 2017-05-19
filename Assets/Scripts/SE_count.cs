using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_count : MonoBehaviour {

	private int count = 0;
	private int count2 = 0;
    public Text spirit_energy;
    public Text collection_energy;
    private AudioSource source;
    public GameObject particles;
    ParticleSystem hitParticles;




    void Start(){
    	source = GetComponent<AudioSource>();
    	spirit_energy.text = "Spirit Energy: 0";
    	collection_energy.text = "Collections: 0";

    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("SpiritEnergy")) 
		{
			source.Play();
			count += 1;
			particles.SetActive(true);
			spirit_energy.text = "Spirit Energy: " + count.ToString();
			StartCoroutine(_Hide());
		}else if (other.gameObject.CompareTag ("Collection")){
			source.Play();
			count2 += 1;
			collection_energy.text = "Collections: " + count2.ToString();
	    	hitParticles = other.GetComponentInChildren <ParticleSystem> ();
			hitParticles.Play();
			StartCoroutine(_reward(other.gameObject));
		}
	}

	private IEnumerator _Hide() {
            yield return new WaitForSeconds(0.5f);
			particles.SetActive(false);
    }

    private IEnumerator _reward(GameObject other) {
            yield return new WaitForSeconds(1.5f);
			other.SetActive(false);
    }
}
