using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimatorBinding : MonoBehaviour
{
    [Header("Player Animation")]
    [SerializeField] private Animator _ANIMATOR_PlayerAnim;

    public static AnimatorBinding Instance;
    private PlayerStates MyState;
    private bool _BOOL_Canplay;
    private bool _BOOL_Locked;
    
    public enum PlayerStates
    {
        Idle,
        Run,
        Attack,
        Tornado,
        GetHit,
        Die
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        MyState = PlayerStates.Idle;
        _BOOL_Canplay = true;
    }

    public void ChangePlayerState(int Index)
    {
        if(_BOOL_Locked){return;}
        if(!_BOOL_Canplay){return;}
        
        MyState = (PlayerStates) Enum.GetValues(typeof(PlayerStates)).GetValue(Index);
        switch (MyState)
        {
            case PlayerStates.Idle:
                _ANIMATOR_PlayerAnim.SetBool("IsMoving", false);
                return;
            case PlayerStates.Run:
                _ANIMATOR_PlayerAnim.SetBool("IsMoving", true);
                return;            
            case PlayerStates.Attack:
                GetRandomAttack();
                _ANIMATOR_PlayerAnim.SetTrigger("Attack");
                StartCoroutine(LockPlay(0.5f));
                return;
            case PlayerStates.Tornado:
                _ANIMATOR_PlayerAnim.SetTrigger("Tornado");
                StartCoroutine(LockPlay(0.3f));
                return; 
            case PlayerStates.GetHit:
                _ANIMATOR_PlayerAnim.SetTrigger("GetHit");
                StartCoroutine(LockPlay(0.3f));
                return; 
            case PlayerStates.Die:
                _ANIMATOR_PlayerAnim.SetTrigger("Dead");
                _BOOL_Locked = true;
                StartCoroutine(LockPlay(1f));
                return; 
        }
    }

    public void BreakLock()
    {
        StopAllCoroutines();
        _BOOL_Canplay = true;
    }
    
    private void GetRandomAttack()
    {
        int RD = Random.Range(0, 3);
        _ANIMATOR_PlayerAnim.SetInteger("AttackState", RD);
    }

    private IEnumerator LockPlay(float Seconds)
    {
        _BOOL_Canplay = false;
        yield return new WaitForSeconds(Seconds);
        _BOOL_Canplay = true;
    }
}
