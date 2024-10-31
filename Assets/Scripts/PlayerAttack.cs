using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("ATTACK PARAMETERS")]
    public int FLOAT_AttackDamage;
    public GameObject _WindParticuleImpact;
    public GameObject _FireParticuleImpact;
    [NonSerialized] public GameObject _PREFAB_ParitculeImpact;


    
    [Space(15)]
    [Foldout("AUTRES")]
    [SerializeField] private TrailRenderer _TRAIL_SwordTrail;
        [Foldout("AUTRES")]
    [SerializeField] private TrailRenderer _TRAIL_SwordTrailFire;
        [Foldout("AUTRES")]
    [SerializeField] private GameObject _GO_SwordHit;
        [Foldout("AUTRES")]
    [SerializeField] private List<GameObject> _LIST_PrefabHit;
        [Foldout("AUTRES")]
    [SerializeField] private GameObject _GO_FireBerserk;
        [Foldout("AUTRES")]
    [NonSerialized] public GameObject GO_PrefabHit;

     private void Start()
     {
         GO_PrefabHit = _LIST_PrefabHit[0];
     }


     public void LightAttack(InputAction.CallbackContext context)
    {
        StartCoroutine(TrailSword());
        AnimatorBinding.Instance.ChangePlayerState(2);
    }
    public void BigAttack(InputAction.CallbackContext context)
    {
        StartCoroutine(TrailSword());
        AnimatorBinding.Instance.ChangePlayerState(3);
    }

    private IEnumerator TrailSword()
    {
        _GO_SwordHit.SetActive(true);
        _TRAIL_SwordTrail.emitting = true;
        _TRAIL_SwordTrailFire.emitting = true;
        yield return new WaitForSeconds(0.3f);
        _TRAIL_SwordTrail.emitting = false;
        _TRAIL_SwordTrailFire.emitting = false;
        _GO_SwordHit.SetActive(false);
    }

    public void ChangeDamage(int damage, bool Berserk = false)
    {
        FLOAT_AttackDamage = damage;
        if (Berserk)
        {
            GO_PrefabHit = _LIST_PrefabHit[1];
            var Fire = Instantiate(_GO_FireBerserk, transform.position, Quaternion.identity, transform);
            Destroy(Fire, 8);
            _TRAIL_SwordTrailFire.gameObject.SetActive(true);
            _TRAIL_SwordTrail.gameObject.SetActive(false);
            _PREFAB_ParitculeImpact = _FireParticuleImpact;
        }
        else
        {
            GO_PrefabHit = _LIST_PrefabHit[0];
            _TRAIL_SwordTrailFire.gameObject.SetActive(false);
            _TRAIL_SwordTrail.gameObject.SetActive(true);
            _PREFAB_ParitculeImpact = _WindParticuleImpact;

        }
    }
}
