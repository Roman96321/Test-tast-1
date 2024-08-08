using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerState))]
public class Character : MonoBehaviour, ICharacter
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private PlayerState _playerState;
    private Rigidbody _rigidBody;
    private Transform _transform;

    private void Start()
    {
        _playerState = GetComponent<PlayerState>();
        _rigidBody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Move(float horizontal, float vertical)
    {
        _rigidBody.velocity = new Vector3(horizontal * moveSpeed, _rigidBody.velocity.y, vertical * moveSpeed);

        if (_rigidBody.velocity == new Vector3(0, _rigidBody.velocity.y, 0))
        {
            _playerState.SetDoesNotMoveState();
            return;
        }

        _playerState.SetMoveState();
    }

    public void Rotate(float horizontal, float vertical)
    {
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        Quaternion toRotation = Quaternion.LookRotation(moveDirection);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
    }
}