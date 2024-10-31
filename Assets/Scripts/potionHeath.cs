using UnityEngine;

public class potionHeath : Item
{
    
    [SerializeField] private float _Float_Health;
    [SerializeField] private Sprite _Sprite_PUSprite;
    public override Sprite SpritePU { get; protected set; } 
    public override float TimeToNormal { get; protected set; }
    public override bool ReturnEffect { get; protected set; }

    private PlayerLife _playerLife;

    private void Awake()
    {
        _playerLife = FindObjectOfType<PlayerLife>();
        SpritePU = _Sprite_PUSprite;
    }

    public override void PlayEffect()
    {
        _playerLife.Gethealth(_Float_Health);
        Destroy(gameObject);
    }

    public override void CancelEffect()
    {
    }
}
