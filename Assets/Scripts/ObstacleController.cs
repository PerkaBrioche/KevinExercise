using System;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private int _INT_ObstacleLife;
    [SerializeField] private Slider _SLIDER_ObstacleSlider;
    [SerializeField] private GameObject _PREF_ParticuleExplosion;

    private void Start()
    {
        _SLIDER_ObstacleSlider.minValue = 0;
        _SLIDER_ObstacleSlider.maxValue = _INT_ObstacleLife;
        _SLIDER_ObstacleSlider.value = _INT_ObstacleLife;
    }

    public void GetDamage(int damage)
    {
        _INT_ObstacleLife -= damage;
        _SLIDER_ObstacleSlider.value = _INT_ObstacleLife;
        if (_INT_ObstacleLife <= 0)
        {
            Instantiate(_PREF_ParticuleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
