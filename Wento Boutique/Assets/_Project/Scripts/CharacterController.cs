using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Transform characterTransform;
    [SerializeField] float multiplier;

    private bool _canMove;
    private float _xAxisMovement;
    private float _yAxisMovement;
    private Vector2 _direction;

    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";


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
        _xAxisMovement = Input.GetAxisRaw(HorizontalAxis);
        _yAxisMovement = Input.GetAxisRaw(VerticalAxis);
        _direction = new Vector2(_xAxisMovement, _yAxisMovement).normalized;
        if(_direction != Vector2.zero)
            MoveCharacter(_direction);
    }

    void MoveCharacter(Vector2 direction)
    {
        float horizontalForce = direction.x * multiplier * Time.deltaTime;
        float verticalForce = direction.y * multiplier * Time.deltaTime;
        Vector3 force = new Vector3(horizontalForce, verticalForce, 0);
        characterTransform.Translate(force, Space.World);
    }
}
