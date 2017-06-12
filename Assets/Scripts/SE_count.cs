using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SE_count : MonoBehaviour {
    public int count2 = 0;
    public Slider spirit_energy;
    public Text collection_energy;
    public AudioSource source;
    public GameObject particles;
    ParticleSystem hitParticles;
    private int goal = 4;

    public GameObject winMenu;
    //GameObject player;
    //PlayerHealth playerHealth;

    void Awake() {
        if (LevelManager.Instance.IsTutorial) {
            this.enabled = false;
            return;
        }
        collection_energy.text = "0/?";
        //player = GameObject.FindGameObjectWithTag ("Player");
        //playerHealth = player.GetComponent<PlayerHealth>();

    }

    private void OnEnable() {
        EventMessenger.StartListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("SpiritEnergy")) {
            source.Play();
            if (!LevelManager.Instance.IsTutorial) {
                particles.SetActive(true);
                StartCoroutine(_UpdateSlider());
                StartCoroutine(_Hide());
            }

        } else if (other.gameObject.CompareTag("Collection")) {
            source.Play();
            if (!LevelManager.Instance.IsTutorial) {
                count2 += 1;
                collection_energy.text = count2.ToString() + "/" + goal.ToString();
                hitParticles = other.GetComponentInChildren<ParticleSystem>();
                hitParticles.Play();
                StartCoroutine(_reward(other.gameObject));
            }
        }
        if (count2 == 9) {
            StartCoroutine(_WinCondition());
        }
    }

    private IEnumerator _Hide() {
        yield return new WaitForSeconds(0.5f);
        particles.SetActive(false);
    }

    private IEnumerator _reward(GameObject other) {
        yield return new WaitForSeconds(.5f);
        other.SetActive(false);
    }

    private IEnumerator _UpdateSlider() {
        yield return null;
        spirit_energy.value = SpiritEnergyManager.Instance.Energy;
    }

    private IEnumerator _WinCondition() {
        winMenu.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Credits");
    }

    private void OnWorldSwitchStarted() {
        StartCoroutine(_UpdateSlider());
    }

    private void OnDisable() {
        EventMessenger.StopListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }
}
