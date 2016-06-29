using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

    public Vector3 rotDirection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            transform.Rotate(rotDirection);
	}
}
