using System;
using System.Collections;

using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : PersistentSingleton<GameManager> {
    protected override void Awake() {
        base.Awake();
        EventMessenger.StartListening(Events.WORLD_SWITCH_POINT, OnWorldSwitchPoint);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && SpiritEnergyManager.Instance.Energy >= 50.0f) {
            SpiritEnergyManager.Instance.Energy -= 50.0f;
            WorldSwitchEffect.Instance.TriggerEffect();
            EventMessenger.TriggerEvent(Events.WORLD_SWITCH_STARTED);
            StartCoroutine(TriggerWorldSwitchEndedEvent());
        }
    }

    private IEnumerator TriggerWorldSwitchEndedEvent() {
        yield return new WaitForSeconds(1.0f);
        EventMessenger.TriggerEvent(Events.WORLD_SWITCH_ENDED);
    }

    private void OnWorldSwitchPoint() {
        LevelManager.Instance.SwitchWorld();
    }

    private void OnDestroy() {
        EventMessenger.StopListening(Events.WORLD_SWITCH_POINT, OnWorldSwitchPoint);
    }
}
