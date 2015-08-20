using UnityEngine;
using System.Collections;

public class PoofChickenDie : MonoBehaviour {

	void Start () {
		Invoke ("Die", 3);
	}
	
	void Die(){
		Destroy (gameObject);
	}
}
