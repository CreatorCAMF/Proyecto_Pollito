using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	//LauncherScript lcs;

	void Start () {
		//lcs = this.transform.parent.GetComponent<LauncherScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Chicken")){
			col.SendMessage("Recycle",SendMessageOptions.RequireReceiver);
			this.transform.parent.SendMessage("ChickUp",SendMessageOptions.RequireReceiver);
		}
	}
}
