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
        for (int i = 0; i < 2; i++) {
            yield return new WaitForSeconds(4f);
            StartCoroutine(blink(i));
        }
        StartCoroutine(blinkLoop());
    }

    IEnumerator blink (int faceToChange) {
        if (faceToChange == 0) {
            sphereMat.material.mainTexture = faces[1];
            yield return new WaitForSeconds(0.3f);
        } else {
            sphereMat.material.mainTexture = faces[2];
            yield return new WaitForSeconds(1.5f);
        }
        sphereMat.material.mainTexture = faces[0];
    }
}
