using UnityEngine;

public class poitionDamage : Item
{
    [SerializeField] private float _Float_TargetDamages;
    [SerializeField] private float _Float_TimeToNormal;
    [SerializeField] private bool _Bool_ReturnEffect;
    [SerializeField] private Sprite _Sprite_PUSprite;
    public override Sprite SpritePU { get; protected set; } 
    public override float TimeToNormal { get; protected set; }
    public override bool ReturnEffect { get; protected set; }

    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = FindObjectOfType<PlayerAttack>();
        TimeToNormal = _Float_TimeToNormal;
        ReturnEffect = _Bool_ReturnEffect;
        SpritePU = _Sprite_PUSprite;

    }

    public override void PlayEffect()
    {
        _playerAttack.ChangeDamage(30, true);
        base.PlayEffect();
    }

    public override void CancelEffect()
    {
        _playerAttack.ChangeDamage(10);
    }
}
