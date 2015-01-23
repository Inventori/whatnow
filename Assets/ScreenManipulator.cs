using UnityEngine;

public class ScreenManipulator : MonoBehaviour {
	void Start () {
		Screen.SetResolution(1920*2 / 4, 1080 / 4, false);
		Debug.Log("Screen resolution modified!");
	}
}
