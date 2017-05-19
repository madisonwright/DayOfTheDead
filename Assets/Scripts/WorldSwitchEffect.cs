using System.Collections;

using UnityEngine;
using UnityEngine.PostProcessing;

public class WorldSwitchEffect : PersistentSingleton<WorldSwitchEffect> {
    public PostProcessingProfile profile;
    public AnimationCurve vignetteIntensityCurve;
    public AnimationCurve vignetteSmoothnessCurve;
    public AnimationCurve dofCurve;
    public AnimationCurve timeScaleCurve;
    public float switchPoint = 1.0f;

    public bool Running {
        get; private set;
    }

    public void TriggerEffect() {
        StartCoroutine(_TriggerEffect());
    }

    private IEnumerator _TriggerEffect() {
        Running = true;
        var vignetteSettings = profile.vignette.settings;
        var dofSettings = profile.depthOfField.settings;

        var switched = false;
        profile.depthOfField.enabled = true;
        for (float t = 0; t < 1.0f; t += Time.unscaledDeltaTime) {
            vignetteSettings.intensity = vignetteIntensityCurve.Evaluate(t);
            vignetteSettings.smoothness = vignetteSmoothnessCurve.Evaluate(t);
            dofSettings.aperture = dofCurve.Evaluate(t);
            profile.vignette.settings = vignetteSettings;
            profile.depthOfField.settings = dofSettings;
            Time.timeScale = timeScaleCurve.Evaluate(t);

            if(t > switchPoint && !switched) {
                EventMessenger.TriggerEvent(Events.WORLD_SWITCH_POINT);
                switched = true;
            }

            yield return null;
        }

        if(!switched) {
            EventMessenger.TriggerEvent(Events.WORLD_SWITCH_POINT);
        }
        Time.timeScale = 1.0f;
        ResetProfile();
        Running = false;
    }

    private void ResetProfile() {
        var vignetteSettings = profile.vignette.settings;
        var dofSettings = profile.depthOfField.settings;
        profile.depthOfField.enabled = false;

        dofSettings.aperture = dofCurve.Evaluate(0);
        vignetteSettings.smoothness = vignetteSmoothnessCurve.Evaluate(0);
        vignetteSettings.intensity = vignetteIntensityCurve.Evaluate(0);

        profile.vignette.settings = vignetteSettings;
        profile.depthOfField.settings = dofSettings;
    }
}
