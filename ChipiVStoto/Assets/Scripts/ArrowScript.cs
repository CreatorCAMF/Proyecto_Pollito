using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	float localAngle;
	LauncherScript ls;
	GameObject chickenLauncher;
	Vector3 size;

	void Start(){
		chickenLauncher = GameObject.FindWithTag ("ChickenLauncher");
		//ls = this.transform.parent.GetComponent<LauncherScript> ();
		ls = chickenLauncher.GetComponent<LauncherScript> ();
		size = this.transform.localScale;
	}

	void Update () {
		localAngle = ls.angle -90;
		transform.rotation = Quaternion.AngleAxis (localAngle , Vector3.forward);
		//Debug.Log (size);
		size.y = ls.force/8;
		//this.transform.localScale = size;
	}
}
