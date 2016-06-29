using UnityEngine;
using System.Collections;
using kode80.PixelRender;

public class SphereScript : MonoBehaviour {

    public Texture[] faces;
    Renderer sphereMat;

	// Use this for initialization
	void Start () {
        sphereMat = GetComponent<Renderer>();
        StartCoroutine(blinkLoop());
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator blinkLoop () {
        yield return new WaitForSeconds(4f);
        StartCoroutine(blink());
    }

    IEnumerator blink () {
        sphereMat.material.mainTexture = faces[1];
        yield return new WaitForSeconds(0.3f);
        sphereMat.material.mainTexture = faces[0];
        StartCoroutine(blinkLoop());
    }
}
