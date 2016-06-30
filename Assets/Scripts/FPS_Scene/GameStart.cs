using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    public RawImage gameViewImg;
    public Text textureResText;
    public Text textureAspectText;
    public Camera pixelCam;

    float mainCamAspect;
    int gameViewWidth;
    int gameViewHeight;

	// Use this for initialization
	void Start () {
        gameViewImg.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        textureResText.text = "Texture Res: " + Screen.width.ToString() + " x " + Screen.height.ToString();
        mainCamAspect = Camera.main.aspect;
        Debug.Log(mainCamAspect.ToString());

        if (mainCamAspect >= 1.7f) {
            textureAspectText.text = "Texture Aspect: 16:9";
            gameViewWidth = 640;
            gameViewHeight = 360;
        } else if (mainCamAspect >= 1.59f) {
            textureAspectText.text = "Texture Aspect: 16:10";
            gameViewWidth = 640;
            gameViewHeight = 400;
        } else if (mainCamAspect >= 1.5f) {
            textureAspectText.text = "Texture Aspect: 3:2";
            gameViewWidth = 480;
            gameViewHeight = 320;
        } else {
            textureAspectText.text = "Texture Aspect: 4:3";
            gameViewWidth = 480;
            gameViewHeight = 360;
        }

        pixelCam.targetTexture.Release();
        pixelCam.targetTexture = new RenderTexture(gameViewWidth, gameViewHeight, 24);
        pixelCam.targetTexture.filterMode = FilterMode.Point;
        gameViewImg.texture = pixelCam.targetTexture;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
