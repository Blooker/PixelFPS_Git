using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float camRotationX = 0;
    private float currentCamRotX = 0;

    [SerializeField]
    private float camRotationLimit = 85f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    public void Move (Vector3 _velocity) {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation) {
        rotation = _rotation;
    }

    public void RotateCam(float _camRotationX) {
        camRotationX = _camRotationX;
    }

    // Update is called once per physics tick
    void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    void PerformMovement() {
        if (velocity != Vector3.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null) {
            currentCamRotX -= camRotationX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotationLimit, camRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }
    }
}
