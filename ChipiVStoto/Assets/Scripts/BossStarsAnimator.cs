using UnityEngine;
using System.Collections;

public class BossStarsAnimator : MonoBehaviour {

	BossParametersScript bps;
	Animator anim;
	
	
	void Start () {
		//bps = this.transform.parent.GetComponent<BossParametersScript>();
		anim = GetComponent<Animator>();
		anim.SetBool("isAlive",true);
	}
	
	void ActivateStars(){
		anim.SetBool("isAlive", false);
	}
	
	
}
