using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    [SerializeField]
    private Vector3[] vertices;
    [SerializeField]
    private Renderer[] laserParts;

    private float alpha = 1f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.6f);
    }
	
	// Update is called once per frame
	void Update () {
        if (alpha > 0)
            alpha -= 0.03f;

        for (int i=0; i<laserParts.Length; i++) {
            laserParts[i].material.color = new Color(1, 1, 1, alpha);
        }
    }
}
