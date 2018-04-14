using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CookieEffects { None, Wet, Doughed}

public class HealthEffects : MonoBehaviour {

    //Time before the effect wears off
    public float doughedWearOffTime = 15;
    public float wetWearOffTime = 15;

    CookieEffects currentEffect = CookieEffects.None;
    float timeSinceEffectGiven;

    private void Start()
    {
        timeSinceEffectGiven = Time.timeSinceLevelLoad;
    }

    public void SetCurrentEffect(CookieEffects effect)
    {
        timeSinceEffectGiven = Time.timeSinceLevelLoad;
        currentEffect = effect;
    }

    public CookieEffects GetCurrentEffect()
    {
        return currentEffect;
    }

    private void Update()
    {
        switch (currentEffect)
        {
            case CookieEffects.Doughed:
                if (timeSinceEffectGiven - Time.timeSinceLevelLoad >= doughedWearOffTime)
                {
                    SetCurrentEffect(CookieEffects.None);
                }
                break;
            case CookieEffects.Wet:
                if (timeSinceEffectGiven - Time.timeSinceLevelLoad >= wetWearOffTime)
                {
                    SetCurrentEffect(CookieEffects.None);
                }
                break;
        }
    }
}
