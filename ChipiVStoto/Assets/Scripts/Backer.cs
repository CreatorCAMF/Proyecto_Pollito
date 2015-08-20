using UnityEngine;
using System.Collections;

public class Backer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Backspace)){
			Application.LoadLevel("Menu");
		}
	}
}
