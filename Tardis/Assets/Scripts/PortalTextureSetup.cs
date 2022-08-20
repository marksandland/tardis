using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Material cameraMaterial1;
	public Material cameraMaterial2;
    
	void Start () {
		if (cam1.targetTexture != null) cam1.targetTexture.Release();
        if (cam2.targetTexture != null) cam2.targetTexture.Release();
        cam1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cam2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterial1.mainTexture = cam1.targetTexture;
        cameraMaterial2.mainTexture = cam2.targetTexture;
	}
}
