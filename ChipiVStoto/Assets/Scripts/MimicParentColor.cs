using UnityEngine;
using System.Collections;

public class MimicParentColor : MonoBehaviour {

	SpriteRenderer srParent;
	SpriteRenderer srLocal;

	void Start () {
		srParent = this.transform.parent.GetComponent<SpriteRenderer> ();
		srLocal = GetComponent<SpriteRenderer>();
	}

	void Update () {
		srLocal.color = srParent.color;
	}
}
