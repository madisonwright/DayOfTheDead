using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : PersistentSingleton<EnemyManager> {

    // Use this for initialization
    protected override void Awake() {
        base.Awake();
        EventMessenger.StartListening(Events.WORLD_SWITCH_POINT, disableEnemy);


    }


    void disableEnemy(){
        Debug.Log (LevelManager.Instance.currentWorld);


        if (LevelManager.Instance.currentWorld == WorldType.Spirt) {
            EnemyHealth[] ene = Resources.FindObjectsOfTypeAll<EnemyHealth>();
            for (int i = 0; i < ene.Length; i++) {

                /*
                 * Since ene array contains the prefeb and we only want to enable the clone enemys
                 * So we check the name contains Clone or not
                */
                if (ene [i].gameObject.name.Contains ("Clone")) {
                    ene[i].gameObject.SetActive (true);
                }

            }
        } 
        else {
            //Debug.Log("EnemyManager: disableEnemy");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

            for (int i = 0; i < enemies.Length; i++) {
                enemies [i].SetActive (false);
            }
        }
    }
}