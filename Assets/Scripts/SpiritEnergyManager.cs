using UnityEngine;
using UnityEngine.UI;

public class SpiritEnergyManager : PersistentSingleton<SpiritEnergyManager> {
    private float _energy = 0.0f;
    public float Energy {
        get {
            return _energy;
        }
        set {
            _energy = value;
            var bar = GameObject.Find("Spirit Energy Bar");
            if (bar) {
                var slider = bar.GetComponent<Slider>();
                slider.value = _energy;
            }
        }
    }
}
