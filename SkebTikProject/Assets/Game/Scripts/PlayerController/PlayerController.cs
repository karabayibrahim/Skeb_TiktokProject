using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _movementClampNegative = -5f;
    private float _movementClampPositive = 5f;

    public float HorizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HorizontalMovement()
    {
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
    }
}
