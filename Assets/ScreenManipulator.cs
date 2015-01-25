using UnityEngine;

public class ScreenManipulator : MonoBehaviour {
	void Start () {
		Screen.SetResolution(1920*2 / 2, 1080 / 2, false);
		Debug.Log("Screen resolution modified!");
		Screen.showCursor = false; 
	}
}
