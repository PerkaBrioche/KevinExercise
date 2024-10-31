using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : MonoBehaviour
{

    [Header("INPUT REFERENCE")]
        [Foldout("INPUT REFERENCE")]
    [SerializeField] private InputActionReference _INPUT_PlayerMovements;
        [Foldout("INPUT REFERENCE")]
    [SerializeField] private InputActionReference _INPUT_LightPlayerAttack;
        [Foldout("INPUT REFERENCE")]
    [SerializeField] private InputActionReference _INPUT_BigPlayerAttack;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        _INPUT_PlayerMovements.action.performed += _playerMovement.OnMovementPerformed;
        _INPUT_PlayerMovements.action.canceled += _playerMovement.OnMovementCanceled;
        
        _INPUT_LightPlayerAttack.action.performed += _playerAttack.LightAttack; 
        _INPUT_BigPlayerAttack.action.performed += _playerAttack.BigAttack; 
    }
    
}
