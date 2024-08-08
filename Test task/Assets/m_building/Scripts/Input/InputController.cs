using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Joystick _inputJoystick;
    [SerializeField] private GameObject _goCharacter;

    private ICharacter _character;

    private void Start()
    {
        _character = _goCharacter.GetComponent<ICharacter>();
    }

    private void Update()
    {
        _character.Move(_inputJoystick.Horizontal, _inputJoystick.Vertical);

        if (_inputJoystick.Horizontal != 0 || _inputJoystick.Vertical != 0)
        {
            _character.Rotate(_inputJoystick.Horizontal, _inputJoystick.Vertical);
        }        
    }
}