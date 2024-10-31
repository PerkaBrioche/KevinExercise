using System;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    [SerializeField] private Transform _TRANSFORM_Player;

    private void Update()
    {
        transform.LookAt(_TRANSFORM_Player);
    }
}
