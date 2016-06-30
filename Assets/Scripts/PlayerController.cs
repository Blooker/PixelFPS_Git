using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    float maxSlope = 60f;

    [SerializeField]
    private Text sensitivityTextBox;
    [SerializeField]
    private GameObject shootPoint;
    [SerializeField]
    private GameObject laserBeam;

    [SerializeField]
    private GameObject playerCam;

    private CharacterMotor motor;
    private string mouseSensText;
    private bool isFalling;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        motor = GetComponent<CharacterMotor>();
        SetSensitivityText();
    }
	
	// Update is called once per frame
	void Update () {
        MoveAndLook();

        if (!isFalling && Input.GetAxis("Jump") > 0) {
            motor.PerformJump(jumpForce);
            isFalling = true;
        }

        if (Input.GetButtonDown("Fire1")) {
            ShootLaser();
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket) && lookSensitivity > 0.5f) {
            lookSensitivity -= 0.5f;
            SetSensitivityText();
        } else if (Input.GetKeyDown(KeyCode.RightBracket) && lookSensitivity < 5.0f) {
            lookSensitivity += 0.5f;
            SetSensitivityText();
        }
    }

    void MoveAndLook () {
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
    }

    void ShootLaser () {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;
        Vector3 shootPointRot = shootPoint.transform.rotation.eulerAngles;
        Vector3 laserRot = new Vector3(shootPointRot.x - 0.5f, shootPointRot.y, shootPointRot.z);

        GameObject newLaser = Instantiate(laserBeam, shootPoint.transform.position, Quaternion.Euler(laserRot)) as GameObject;

        if (Physics.Raycast(ray, out hit, 100))
            newLaser.transform.LookAt(hit.point, Vector3.up);

        Debug.Log(ray.GetPoint(100));
    }

    void SetSensitivityText() {
        mouseSensText = "Sensitivity: " + lookSensitivity.ToString();
        sensitivityTextBox.text = mouseSensText;
    }

    void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint c in collision.contacts) {
            //if (c.otherCollider.tag == walkableTag)
            isFalling = false;
        }
    }

    void OnCollisionExit () {
        isFalling = true;
    }

    /*void OnCollisionStay(Collision coll) {
        foreach (ContactPoint contact in coll.contacts) {
            if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
                isFalling = false;
        }
    }

    void OnCollisionExit () {
        isFalling = true;
    }*/
}
