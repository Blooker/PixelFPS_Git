using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private Material[] floorMats;
    private Renderer floorRender;
    
	// Use this for initialization
	void Start () {
        floorRender = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if ((player.transform.position.y - transform.position.y) >= 80f) {
            floorRender.material = floorMats[1];
        } else {
            floorRender.material = floorMats[0];
        }
	}
}
