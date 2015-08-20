using UnityEngine;
using System.Collections;

public class CatCollider : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite initialFace; 
	public Sprite hurtFace;
	public Sprite finalFace;
	bool ff;

	void Start(){
		sr = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Chicken")){
			this.transform.parent.SendMessage("LifeLess",1,SendMessageOptions.RequireReceiver);
			StartCoroutine("SwitchFace");
		}
	}

	IEnumerator SwitchFace(){
		if (!ff) {
			sr.sprite = hurtFace;
			yield return new WaitForSeconds (0.5f);
			sr.sprite = initialFace;
		}
		
	}

	/*void Update(){
		if (ff) {
			sr.sprite = finalFace;
		}
	}*/

	void Die(){
		ff = true;
		sr.sprite = finalFace;
		Destroy (this);
	}
}
