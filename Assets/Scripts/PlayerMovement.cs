using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("MOVEMENT PARAMETERS")]
    [SerializeField] private float _FLOAT_Speed;

    private Rigidbody _rigidbody;
    private Vector2 _inputVector;

    private bool _BOOL_IsMoving;
    private bool _BOOL_CanMove;
    
    




    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _BOOL_CanMove = true;
    }

    public void OnMovementPerformed(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }

    public void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _inputVector = Vector2.zero;
    }

    void FixedUpdate()
    {
        if(!_BOOL_CanMove){return;}
        if (_inputVector != Vector2.zero)
        {
            AnimatorBinding.Instance.ChangePlayerState(1);
            _BOOL_IsMoving = true;
        }
        else
        {

            AnimatorBinding.Instance.ChangePlayerState(0);
            _BOOL_IsMoving = false;
        }
        
        Vector3 movement = new Vector3(_inputVector.x, 0, _inputVector.y).normalized;
        _rigidbody.AddForce(movement * _FLOAT_Speed * Time.fixedDeltaTime);
        transform.LookAt(transform.position + movement);
    }

    public void PushPlayer()
    {
        StartCoroutine(CouroutinePush());
    }

    private IEnumerator CouroutinePush()
    {
        Vector3 MyVector = transform.position;
        Vector3 TargetPosition = new Vector3(MyVector.x, MyVector.y + 3, MyVector.z);
        float CurrentAlpha = 0;
        while (CurrentAlpha < 1)
        {
            transform.position = Vector3.Lerp(MyVector, TargetPosition, CurrentAlpha);
            CurrentAlpha += Time.deltaTime * 2;
            yield return null;
        }
    }

    public void FreezePlayer()
    {
        _BOOL_CanMove = false;
    }
    public void UnFreezePlayer()
    {
        _BOOL_CanMove = true;
    }
    public void FreezePlayerTime(float Seconds)
    {
        StartCoroutine(FreezePlayerFor(Seconds));
    }
    private IEnumerator FreezePlayerFor(float freezeTime)
    {
        FreezePlayer();
        yield return new WaitForSeconds(freezeTime);
        UnFreezePlayer();
    }

    public void ChangeSpeed(float NewSpeed)
    {
        _FLOAT_Speed = NewSpeed;
    }
}