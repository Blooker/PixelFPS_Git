using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private Text sensitivityTextBox;

    private CharacterMotor motor;
    private string mouseSensText;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        motor = GetComponent<CharacterMotor>();
        SetSensitivityText();
    }
	
	// Update is called once per frame
	void Update () {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _camRotationX = _xRot * lookSensitivity;

        motor.RotateCam(_camRotationX);

        if (Input.GetKeyDown(KeyCode.LeftBracket) && lookSensitivity > 0.5f) {
            lookSensitivity -= 0.5f;
            SetSensitivityText();
        } else if (Input.GetKeyDown(KeyCode.RightBracket) && lookSensitivity < 5.0f) {
            lookSensitivity += 0.5f;
            SetSensitivityText();
        }
    }

    void SetSensitivityText() {
        mouseSensText = "Sensitivity: " + lookSensitivity.ToString();
        sensitivityTextBox.text = mouseSensText;
    }

}
