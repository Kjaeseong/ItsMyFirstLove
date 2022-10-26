using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPSUI : MonoBehaviour
{
    private GameObject _vpsEffect;

    public void EffectObjectSet(GameObject effect)
    {
        _vpsEffect = effect;
    }

    public void DeactivateVPSEffect()
    {
        _vpsEffect.SetActive(false);
        gameObject.SetActive(false);
    }
}
