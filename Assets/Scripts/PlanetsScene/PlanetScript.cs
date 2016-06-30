using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {

    [SerializeField]
    private GameObject cube;

    private Renderer planetRender;
    private Vector3 lightDir;
    private float lightXIncrease = 0.01f;

	// Use this for initialization
	void Start () {
        planetRender = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cube != null) {
            lightDir = cube.transform.position - transform.position;
            transform.LookAt(cube.transform.position, Vector3.right);
            planetRender.material.SetVector("_LightDir", new Vector4(lightDir.x, lightDir.y, lightDir.z, 1));
        }
	}
}
