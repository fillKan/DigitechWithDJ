using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenPlayer : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem PollenParticle;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            PollenParticle.gameObject.SetActive(true);
            PollenParticle.Play(true);
        }
#else
        if (Input.touchCount > 0)
        {
            PollenParticle.gameObject.SetActive(true);
            PollenParticle.Play(true);
        }
#endif
    }
}
