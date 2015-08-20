using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {

	public float life;
	public float diff;
	SpriteRenderer sr;
	public float timeOff;
	public bool below50;
	public bool below25;
	public bool below10;
	float MAX_LIFE;
	float contador;
	Vector3 colorA;
	bool alive;
	int routine;

	void Start(){
		//diff = PlayerPrefs.GetInt ("Dificultad");
		sr = this.GetComponent<SpriteRenderer> ();
		MAX_LIFE = 9 + diff;
		life = MAX_LIFE;
		below10 = false;
		below25 = false;
		below50 = false;
		contador = 0;
		colorA.x = 1;
		colorA.y = 1;
		colorA.z = 1;
		alive = true;
	}

	void LifeLess(float ll){
		if (life - ll > 0) {
			life -= ll;
			//StartCoroutine(AlternateColor());
		} else {
			life = 0;
			alive = false;
			//CatCollider ct = GetComponentInChildren<CatCollider>();
			//ct.SendMessage("Die");
			//Debug.Log("Message sent");
		}
	}

	void Update(){
		if(alive){
			if ((life* 100)/ MAX_LIFE < 50 && !below50) {
				below50 = true;			
			}
			if ((life* 100)/ MAX_LIFE < 25 && !below25) {
				below25 = true;
			}
			if ((life* 100)/ MAX_LIFE < 10 && !below10) {
				below10 = true;
			}
			if (below50) {
				contador = 0.01f;
			}
			if (below25) {
				contador = 0.03f;
			}
			if (below10) {
				contador = 0.06f;
			}
			colorA.y -= contador;
			colorA.z -= contador;
			sr.color = new Color (colorA.x,colorA.y,colorA.z);
			if (colorA.z <= 0 && colorA.y <= 0) {
				colorA.y = 1;
				colorA.z = 1;
			}
			if(!below50 && !below25 && !below10){
				contador = 0;
				TurnWhite();
			}
		}else{
			TurnWhite();
		}
	
	}

	IEnumerator AlternateColor(){
		TurnRed ();
		yield return new WaitForSeconds(timeOff);
		TurnWhite();
	}

	void TurnRed(){
		sr.color = new Color(1f,0f,0f);
	}

	void TurnWhite(){
		sr.color = new Color(1f,1f,1f);
	}

}
