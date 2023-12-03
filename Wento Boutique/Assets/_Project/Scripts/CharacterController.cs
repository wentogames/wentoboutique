using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform characterTransform;
    [SerializeField] Animator characterAnimator;
    [SerializeField] float multiplier;

    private bool _canMove;
    private float _xAxisMovement;
    private float _yAxisMovement;
    private Vector2 _direction;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string xMovementParameter = "xMovement";
    private const string yMovementParameter = "yMovement";
    private const string zeroMovementParameter = "zeroMovement";
    private const float movementThreshold = 0.01f;


    void Start()
    {
        _canMove = true;
    }

    void Update()
    {
        if(_canMove)
            OnInputDown();
    }

    void OnInputDown()
    {
        _xAxisMovement = Input.GetAxis(HorizontalAxis);
        _yAxisMovement = Input.GetAxis(VerticalAxis);
        _direction = new Vector2(_xAxisMovement, _yAxisMovement);
        if(_direction != Vector2.zero && !IsOnThreshold(_direction))
            MoveCharacter(_direction);
        else
            ChangeAnimation(Vector2.zero);
    }

    void MoveCharacter(Vector2 direction)
    {
        float horizontalForce = direction.x * multiplier * Time.deltaTime;
        float verticalForce = direction.y * multiplier * Time.deltaTime;
        ChangeAnimation(direction);
        Vector3 force = new Vector3(horizontalForce, verticalForce, 0);
        characterTransform.Translate(force, Space.World);
    }

    void ChangeAnimation(Vector2 direction)
    {
        Debug.Log("dir: " + direction);
        if (direction == Vector2.zero)
        {
            characterAnimator.SetBool(zeroMovementParameter, true);
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            Debug.Log("dir y: " + direction.y);
            characterAnimator.SetFloat(yMovementParameter, direction.y);
            characterAnimator.SetFloat(xMovementParameter, 0);
            characterAnimator.SetBool(zeroMovementParameter, false);
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Debug.Log("dir y: " + direction.x);
            characterAnimator.SetFloat(xMovementParameter, direction.x);
            characterAnimator.SetFloat(yMovementParameter, 0);
            characterAnimator.SetBool(zeroMovementParameter, false);
        }
    }

    bool IsOnThreshold(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < movementThreshold && Mathf.Abs(direction.y) < movementThreshold)
            return true;
        return false;
    }
}
