using UnityEngine;
using System.Collections;

public class BossFace : MonoBehaviour {

	SpriteRenderer sr;
	BossParametersScript bps;
	public Sprite initialFace; 
	public Sprite hurtFace;
	public Sprite finalFace;
	bool aliveChild;
	public bool hurt;
	float currentLife;
	public bool below50;
	public bool below25;
	public bool below10;
	float MAX_LIFE;
	float contador;
	Vector3 colorA;
	
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		bps = this.transform.parent.GetComponent<BossParametersScript>();
		aliveChild = bps.isAlive;
		
		currentLife = bps.CurrentLife;
		hurt = false;
		below50 = false;
		below25 = false;
		below10 = false;
		contador = 0;
		colorA.x = 1;
		colorA.y = 1;
		colorA.z = 1;
	}
	
	
	void Update () {
		aliveChild = bps.isAlive;
		currentLife = bps.CurrentLife;
		MAX_LIFE = bps.Max_life;
		if(!aliveChild){
			sr.sprite = finalFace;
			TurnWhite();
		}else {		
			if ((currentLife* 100)/ MAX_LIFE < 50 && !below50) {
				below50 = true;			
			}
			if ((currentLife* 100)/ MAX_LIFE < 25 && !below25) {
				below25 = true;
			}
			if ((currentLife* 100)/ MAX_LIFE < 10 && !below10) {
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
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Chicken")){
			if(aliveChild){
				col.SendMessage("BecomeInmune");
				this.transform.parent.SendMessage("LifeLess",1,SendMessageOptions.RequireReceiver);
				StartCoroutine("SwitchFace");
			}
		}
	}
	
	IEnumerator SwitchFace(){
		if (aliveChild) {
			sr.sprite = hurtFace;
			hurt = true;
			yield return new WaitForSeconds (0.5f);
			sr.sprite = initialFace;
			hurt = false;
		}	
	}
	
	void TurnWhite(){
		sr.color = new Color(1f,1f,1f);
	}
	
}
