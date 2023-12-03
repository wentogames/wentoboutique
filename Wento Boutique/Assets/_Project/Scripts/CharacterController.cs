using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform characterTransform;
    [SerializeField] Animator characterAnimator;
    [SerializeField] BoxCollider2D characterCollider;
    [SerializeField] float multiplier;

    private bool _canMove;
    private float _xAxisMovement;
    private float _yAxisMovement;
    private Vector2 _direction;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string XMovementParameter = "xMovement";
    private const string YMovementParameter = "yMovement";
    private const string ZeroMovementParameter = "zeroMovement";
    private const float MovementThreshold = 0.01f;
    private const string MirrorTag = "Mirror";


    void Start()
    {
        _canMove = true;
    }

    void FixedUpdate()
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
        if (direction == Vector2.zero)
        {
            characterAnimator.SetBool(ZeroMovementParameter, true);
        }
        else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            characterAnimator.SetFloat(YMovementParameter, direction.y);
            characterAnimator.SetFloat(XMovementParameter, 0);
            characterAnimator.SetBool(ZeroMovementParameter, false);
        }
        else if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            characterAnimator.SetFloat(XMovementParameter, direction.x);
            characterAnimator.SetFloat(YMovementParameter, 0);
            characterAnimator.SetBool(ZeroMovementParameter, false);
        }
    }

    bool IsOnThreshold(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < MovementThreshold && Mathf.Abs(direction.y) < MovementThreshold)
            return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == MirrorTag)
        {
            CanvasManager.Instance.ToggleShortcutPanel(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == MirrorTag)
        {
            CanvasManager.Instance.ToggleShortcutPanel(false);
        }
    }
}
