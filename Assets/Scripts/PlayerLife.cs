using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class PlayerLife : MonoBehaviour
{
    [Header("LIFE PARAMETERS")]
    [SerializeField] private float _INT_MaxLife;
    [SerializeField, ShowIf("IsRuntime")] public float INT_Life;

    [Button]
    public void TestDamage()
    {
        INT_Life -= 10;
    }
    
    bool IsRuntime()
    {
        return Application.isPlaying;
    }

    [Foldout("AUTRES")]
    [SerializeField] private Slider _SLIDER_LifeSlider;
    [Foldout("AUTRES")]
    [SerializeField] private GameObject _PREFAB_ParticuleDeath;
    [Foldout("AUTRES")]
    [SerializeField] private CinemachineVirtualCamera _cinemachine;
    [Space(15)]


    private PlayerMovement _playerMovement;

    private void OnValidate()
    {
        if (_INT_MaxLife < 1)
        {
            _INT_MaxLife = 1;
        }
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Awake()
    {
        INT_Life = _INT_MaxLife;
    }

    public void GetDamage(int damage)
    {
        INT_Life -= damage;
        GetComponent<PlayerMovement>().PushPlayer();
        AnimatorBinding.Instance.ChangePlayerState(4);
        UpdateSlider();

        if (INT_Life <= 0)
        {
            PlayerDie();
        }
        else
        {
            _playerMovement.FreezePlayerTime(0.3f);
        }
    }

    public void Gethealth(float Health)
    {
        INT_Life += Health;
        if (INT_Life > _INT_MaxLife)
        {
            INT_Life = _INT_MaxLife;
        }
        UpdateSlider();
    }

    private void PlayerDie()
    {
        _playerMovement.FreezePlayer();
        AnimatorBinding.Instance.BreakLock();
        AnimatorBinding.Instance.ChangePlayerState(5);
        Instantiate(_PREFAB_ParticuleDeath, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
        StartCoroutine(ZoomCamera());
    }

    private void UpdateSlider()
    {
        _SLIDER_LifeSlider.value = INT_Life;
    }

    private IEnumerator ZoomCamera()
    {
        float TargetZoom = 24;
        while (_cinemachine.m_Lens.FieldOfView > TargetZoom)
        {
            _cinemachine.m_Lens.FieldOfView -= 0.5f;
            yield return null;
        }
    }

}
