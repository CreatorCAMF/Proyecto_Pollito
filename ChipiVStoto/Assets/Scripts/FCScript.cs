using UnityEngine;
using System.Collections;

public class FCScript : MonoBehaviour {

	public GameObject poofChicken;
	bool isInmune = false;

	void Start () {
		Invoke ("Die", 20);
	}

	void Die(){
		if(!isInmune){
			Instantiate (poofChicken, this.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void Recycle(){
		//Instantiate (poofChicken, this.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		Vector3 rb;
		if(col.CompareTag("Wall")/* || col.CompareTag("Chicken")*/){
			rb = this.rigidbody2D.velocity;
			rb.x *= -1;
			this.rigidbody2D.velocity = rb;
		}
	}
	
	void BecomeInmune(){
		isInmune = true;
	}
}
