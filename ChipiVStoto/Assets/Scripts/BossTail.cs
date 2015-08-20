using UnityEngine;
using System.Collections;

public class BossTail : MonoBehaviour {

	public Sprite normalTail;
	public Sprite hurtTail;
	SpriteRenderer sr;
	BossFace bf;
	
	void Start () {
		bf = this.transform.parent.GetComponent<BossFace>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(bf.hurt){
			sr.sprite = hurtTail;
		}else{
			sr.sprite = normalTail;
		}
	}
}
