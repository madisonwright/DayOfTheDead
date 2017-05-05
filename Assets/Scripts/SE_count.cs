using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE_count : MonoBehaviour {

	private int count = 0;
    public Text spirit_energy;
    private AudioSource source;
    public AudioClip chime;

    void Start(){
    	source = GetComponent<AudioSource>();
    	spirit_energy.text = "Spirit Energy: 0";
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("SpiritEnergy")) 
		{
			source.PlayOneShot(chime);
			count += 1;
			spirit_energy.text = "Spirit Energy: " + count.ToString();
		}
	}
}
