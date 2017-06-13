using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SE_count : MonoBehaviour {
    public int count2 = 0;
    private int count3 = 0;
    public Slider spirit_energy;
    public Text collection_energy;
    public AudioSource source;
    public GameObject particles;
    public Image end_text1;
    public Image end_text2;
    ParticleSystem hitParticles;
    private int goal = 0;
    public GameObject playerr;


    public GameObject winMenu;


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
                count3 += 1;
                if (0 <= count2  & count2 <= 3){
                    goal = 4;
                } else if (4 <= count2 & count2 < 7){
                    goal = 3;
                    if (count3 == 4){
                        count3 -= 4;}
                } else{
                    if (count3 == 3){
                        count3 -= 3;
                    }
                }
                collection_energy.text = count3.ToString() + "/" + goal.ToString();
                hitParticles = other.GetComponentInChildren<ParticleSystem>();
                hitParticles.Play();
                StartCoroutine(_reward(other.gameObject));
            }
        }
        if (count2 == 10) {
            StartCoroutine(_end_text());
            StartCoroutine(_WinCondition());
        }
    }

    private IEnumerator _end_text() {
        playerr.GetComponent<SE_count>().end_text1.gameObject.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        playerr.GetComponent<SE_count>().end_text1.gameObject.SetActive(false);
        StartCoroutine(_end_text2());
    }

    private IEnumerator _end_text2() {
        playerr.GetComponent<SE_count>().end_text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        playerr.GetComponent<SE_count>().end_text2.gameObject.SetActive(false);
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
        //winMenu.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("Credits");
    }

    private void OnWorldSwitchStarted() {
        StartCoroutine(_UpdateSlider());
    }

    private void OnDisable() {
        EventMessenger.StopListening(Events.WORLD_SWITCH_STARTED, OnWorldSwitchStarted);
    }
}
