using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioSource source;  
    public AudioSource source2;
    public Transform PickupSpiritEnergy;
    private float x;

    GameObject player;
    Animator anim;
    ParticleSystem hitParticles;
    BoxCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <BoxCollider> ();
        player = GameObject.FindGameObjectWithTag ("Player");
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount) //, Vector3 hitPoint)
    {
        if(isDead)
            return;

        source.Play();
        currentHealth -= amount;
        gameObject.transform.LookAt (player.transform.position);
        gameObject.transform.position += (gameObject.transform.position - player.transform.position) / 4.0F;

        //hitParticles.transform.position = hitPoint;

        if(currentHealth <= 0)
        {
            hitParticles.Play();
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.enabled = false;
        source2.Play();
        x = Random.Range(1, 4);
        for (int i = 0; i < x; i++)
        {
            Instantiate(PickupSpiritEnergy, gameObject.transform.position, Quaternion.identity);
        }
        StartSinking ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        Destroy (gameObject, 2f);
    }
}