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
        //Debug.Log (LevelManager.Instance.currentWorld);
        SpiritPickupController[] spiritEnergy = Resources.FindObjectsOfTypeAll<SpiritPickupController> ();

        for (int s = 0; s < spiritEnergy.Length; s++) {
            if (spiritEnergy [s].gameObject.name.Contains ("Clone")) {
                Destroy(spiritEnergy [s].gameObject);
            }
        }

        EnemyHealth[] ene = Resources.FindObjectsOfTypeAll<EnemyHealth>();
        StarEnemyHealth[] starH = Resources.FindObjectsOfTypeAll<StarEnemyHealth>();

        if (LevelManager.Instance.currentWorld == WorldType.Spirt) {
           
            for (int i = 0; i < ene.Length; i++) {

                /*
                 * Since ene array contains the prefeb and we only want to enable the clone enemys
                 * So we check the name contains Clone or not
                */
                if (ene [i].gameObject.name.Contains ("Clone")) {
                    if (ene [i].gameObject.activeSelf) {
                        ene [i].gameObject.SetActive (false);
                    } else{
                        ene [i].gameObject.SetActive (true);
                    }
                }
            }

            for (int j = 0; j < starH.Length; j++) {
                if (starH[j].gameObject.name.Contains ("Clone")) {
                    if (starH [j].gameObject.activeSelf) {
                        starH [j].gameObject.SetActive (false);
                    } else {
                        starH[j].gameObject.SetActive (true);
                           
                    }
                }
            }
        } 
        else {
            //Debug.Log("EnemyManager: disableEnemy");

            for (int l = 0; l < ene.Length; l++) {
                if (ene [l].gameObject.name.Contains ("Clone")) {
                    if (ene [l].gameObject.activeSelf) {
                        ene [l].gameObject.SetActive (false);
                    } else {
                        ene [l].gameObject.SetActive (true);
                    }
                }

            }
            for (int k = 0; k < starH.Length; k++) {
                if (starH [k].gameObject.name.Contains ("Clone")) {
                    if (starH [k].gameObject.activeSelf) {
                        starH [k].gameObject.SetActive (false);
                    } else {
                        starH [k].gameObject.SetActive (true);
                    }
                }

            }
        }
    }
}