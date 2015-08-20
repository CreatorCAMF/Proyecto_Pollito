using UnityEngine;
using System.Collections;

public class BossHandAnimator2 : MonoBehaviour {

	Animator anim;
	//int animSpeed;
	BossParametersScript bps;
	float attackTime = 5;
	//bool toAttack = false;
	
	void Start () {
		anim = GetComponent<Animator>();
		bps = this.transform.parent.GetComponent<BossParametersScript>();
		attackTime = 1 - Mathf.Log(bps.diffic) + 2;
		InvokeRepeating("SendAttack",0,attackTime);
		//anim.speed = bps.diffic/10;
	}
	
	void SendAttack(){
		if(bps.isAlive){
			StartCoroutine("Attack");
		}
	}
	
	IEnumerator Attack(){
		//Debug.Log("attack");
		anim.SetBool("Attack",true);
		yield return new WaitForSeconds(0.1f);
		anim.SetBool("Attack",false);
	}
	
}
