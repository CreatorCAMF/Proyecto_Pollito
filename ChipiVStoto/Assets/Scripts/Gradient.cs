using UnityEngine;
using System.Collections;

public class Gradient : MonoBehaviour {

	SpriteRenderer sr;
	Vector3 colorS;

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		colorS.x = 1;//Red
		colorS.y = 1;//Green
		colorS.z = 1;//Blue
	}

	void Update () {
		sr.color = new Color (colorS.x,colorS.y,colorS.z);
		colorS.x -= 0.01f;
		colorS.y -= 0.01f;
	}
}
