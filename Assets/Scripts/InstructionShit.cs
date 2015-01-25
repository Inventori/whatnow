using UnityEngine;
using System.Collections;

public class InstructionShit : MonoBehaviour {

	
	public GameObject[] instructionArray;
	public int i;
	
	// Use this for initialization
	void Start () {
	i = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0))
		{
			i++;
			transform.position = new Vector3(instructionArray[i].transform.position.x, instructionArray[i].transform.position.y, transform.position.z);
			if (i > 5)
			{
				Application.LoadLevel(1);
			}
		}
		
	}
}
