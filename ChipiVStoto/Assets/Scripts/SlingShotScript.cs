using UnityEngine;
using System.Collections;

public class SlingShotScript : MonoBehaviour {

	public float localAngle;
	public float localForce;
	public GameObject chicken;
	LauncherScript lcs;
	int cl;

	void Start(){
		//red = GameObject.FindWithTag ("Arrow");
		lcs = this.transform.parent.GetComponent<LauncherScript>();
	}

	void Shoot(){
		bool uno, dos;
		uno = lcs.shoot1;
		dos = lcs.shoot2;
		Vector2 v2d;
		if (uno && dos) {
			if (cl > 0) {
				GameObject chickenCopy = Instantiate (chicken, this.transform.position, Quaternion.AngleAxis (localAngle, Vector3.forward)) as GameObject;
				v2d.x =	Mathf.Cos((localAngle*Mathf.PI)/180);
				v2d.y = Mathf.Sin((localAngle*Mathf.PI)/180);
				chickenCopy.rigidbody2D.AddForce (v2d * localForce,ForceMode2D.Impulse);
				this.transform.parent.SendMessage("ChickLess",SendMessageOptions.RequireReceiver);
			}
		}
	}

	void Update () {
		localAngle = lcs.angle;
		localForce = lcs.force;
		cl = lcs.chicksLeft;
		if (Input.GetKeyDown(KeyCode.Return)) {
			Shoot();
		}
	}
}
