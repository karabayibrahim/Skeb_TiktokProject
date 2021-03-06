using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour
{
    private float _movementClampNegative = -15.5f;
    private float _movementClampPositive = 15.5f;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private int _gateIndex;

    public float swerveSpeed;
    public Female Female;
    public Male Male;
    public GameObject MaleObj;
    public GameObject FemaleObj;
    public GameObject MainPhone;
    
    public float MoveFactorX => _moveFactorX;
    public float MoveSpeed;
    public float HorizontalSpeed;
    public static Action WalkActon;
    public static Action IdleAction;
    public Transform Cameraman;
    public bool GateTrigged = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public int GateIndex
    {
        get
        {
            return _gateIndex;
        }
        set
        {
            if (GateIndex==value)
            {
                return;
            }
            _gateIndex = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState==GameState.PLAY)
        {
            if (Input.GetMouseButtonDown(0))
            {
                WalkActon?.Invoke();
            }
            if (Input.GetMouseButton(0))
            {
                VerticalMove();
                //HorizontalMovement();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                IdleAction?.Invoke();
            }
            HorizontalMovement();
        }
        

    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ICollectable>()!=null)
        {
            other.GetComponent<ICollectable>().DoCollect(GateIndex);
            other.GetComponent<ICollectable>().DoCollectNotIndex();
        }
    }

    public void VerticalMove()
    {
        transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
    }

    private void HorizontalMovement()
    {
        #region MobileHorizontal
        if (Input.touchCount > 0)
        {
            Touch _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Moved)
            {
                Vector2 touchPos = _theTouch.deltaPosition;
                if (touchPos != Vector2.zero)
                {
                    transform.Translate(-touchPos.x * (HorizontalSpeed / 100) * Time.deltaTime, 0, 0);
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, _movementClampNegative, _movementClampPositive), transform.position.y, transform.position.z);
                }
            }
        }
        #endregion
        //float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        //transform.Translate(-swerveAmount, 0, 0);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _lastFrameFingerPositionX = Input.mousePosition.x;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
        //    _lastFrameFingerPositionX = Input.mousePosition.x;
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    _moveFactorX = 0f;
        //}
    }
}
