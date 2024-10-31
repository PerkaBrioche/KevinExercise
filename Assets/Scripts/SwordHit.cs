using System;
using Cinemachine;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    [SerializeField] private Transform _TRANSFORM_TextSpawner;
    [SerializeField] private CinemachineImpulseSource _CinemachineImpulse;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = FindObjectOfType<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            var _PREFAB_ParticuleText = _playerAttack.GO_PrefabHit;
            var _PREFAB_ParticuleImpact = _playerAttack._PREFAB_ParitculeImpact;
            Instantiate(_PREFAB_ParticuleImpact, transform.position, _PREFAB_ParticuleImpact.transform.rotation);
            Instantiate(_PREFAB_ParticuleText, _TRANSFORM_TextSpawner.position, _PREFAB_ParticuleText.transform.rotation);
            _CinemachineImpulse.GenerateImpulse();
            other.GetComponent<ObstacleController>().GetDamage(_playerAttack.FLOAT_AttackDamage);
        }
    }
}
