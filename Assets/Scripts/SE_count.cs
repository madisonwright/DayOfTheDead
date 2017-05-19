using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_count : MonoBehaviour {

	private int count = 0;
    public Text spirit_energy;
    private AudioSource source;
    public GameObject particles;

    void Start(){
    	source = GetComponent<AudioSource>();
    	spirit_energy.text = "Spirit Energy: 0";
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("SpiritEnergy")) 
		{
			source.Play();
			count += 1;
			particles.SetActive(true);
			spirit_energy.text = "Spirit Energy: " + count.ToString();
			StartCoroutine(_Hide());
		}
	}

	private IEnumerator _Hide() {
            yield return new WaitForSeconds(0.5f);
			particles.SetActive(false);
    }
}
