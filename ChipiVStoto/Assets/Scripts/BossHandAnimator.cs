using UnityEngine;
using System.Collections;

public class BossHandAnimator : MonoBehaviour {

	Animator anim;
	int rout = 1;
	public int animations = 1;
	//int animSpeed;
	BossParametersScript bps;
	
	void Start () {
		anim = GetComponent<Animator>();
		InvokeRepeating("ChangeRoutine",0,5);
		bps = this.transform.parent.GetComponent<BossParametersScript>();
		anim.speed = bps.diffic/5;
		//Debug.Log("Speed " + anim.speed);
	}
	
	void Update () {
		if(!bps.isAlive){
			anim.speed = 0;
		}
	}
	
	void ChangeRoutine(){
		rout = (int)Random.Range(0,animations) + 1;
		anim.SetInteger("Routine",rout);
	}
}
