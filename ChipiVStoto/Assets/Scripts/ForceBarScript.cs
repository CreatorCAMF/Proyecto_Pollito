using UnityEngine;
using System.Collections;

public class ForceBarScript : MonoBehaviour {

	float localsize;
	float localAngle;
	LauncherScript ls;
	
	void Start(){
		ls = this.transform.parent.GetComponent<LauncherScript> ();
	}
	
	void Update () {
		//localsize = ls.force;
		localAngle = ls.angle -90;
		transform.rotation = Quaternion.AngleAxis (localAngle , Vector3.forward);
		/*Vector3 tama = this.transform.localScale;
		tama.y = localsize/2;
		this.transform.localScale = tama;*/
	}
}
