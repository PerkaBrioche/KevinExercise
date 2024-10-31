using System;
using System.Collections;
using UnityEngine;

public class PotionSpeed : Item
{
    [SerializeField] private float _Float_TargetSpeed;
    [SerializeField] private float _Float_TimeToNormal;
    [SerializeField] private bool _Bool_ReturnEffect;
    [SerializeField] private Sprite _Sprite_PUSprite;
    public override Sprite SpritePU { get; protected set; } 
    public override float TimeToNormal { get; protected set; }
    public override bool ReturnEffect { get; protected set; }

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        TimeToNormal = _Float_TimeToNormal;
        ReturnEffect = _Bool_ReturnEffect;
        SpritePU = _Sprite_PUSprite;
    }

    public override void PlayEffect()
    {
        _playerMovement.ChangeSpeed(_Float_TargetSpeed);
        base.PlayEffect();
    }

    public override void CancelEffect()
    {
        _playerMovement.ChangeSpeed(250);
    }
}