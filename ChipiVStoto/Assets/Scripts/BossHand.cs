using UnityEngine;
using System.Collections;

public class BossHand : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Chicken")){
			col.SendMessage("Die",SendMessageOptions.RequireReceiver);
		}
	}
}
