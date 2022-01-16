using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    private float _movementClampNegative = -5f;
    private float _movementClampPositive = 5f;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;

    public float swerveSpeed;
    public float MoveFactorX => _moveFactorX;
    public float MoveSpeed;
    public float HorizontalSpeed;
    public static Action WalkActon;
    public static Action IdleAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            WalkActon?.Invoke();
        }
        if (Input.GetMouseButton(0))
        {
            HorizontalMovement();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            IdleAction?.Invoke();
        }
        
    }

    private void HorizontalMovement()
    {
        transform.Translate(0,0,MoveSpeed*Time.deltaTime);
        #region MobileHorizontal
        if (Input.touchCount > 0)
        {
            Touch _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Moved)
            {
                Vector2 touchPos = _theTouch.deltaPosition;
                if (touchPos != Vector2.zero)
                {
                    transform.Translate(touchPos.x * (HorizontalSpeed / 100) * Time.deltaTime, 0, 0);
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, _movementClampNegative, _movementClampPositive), transform.position.y, transform.position.z);
                }
            }
        }
        #endregion
        float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        transform.Translate(-swerveAmount, 0, 0);
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }
    }
}
