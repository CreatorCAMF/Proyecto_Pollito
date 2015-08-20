using UnityEngine;
using System.Collections;

public class CatBar : MonoBehaviour {

	 
	CatScript cs;

	void Start () {
		cs = this.transform.parent.GetComponent<CatScript> ();
	}

	void Update () {
		Vector3 tam = this.transform.localScale;
		tam.x = cs.life;
		this.transform.localScale = tam;
	}
}
