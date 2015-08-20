using UnityEngine;
using System.Collections;

public class chocotecho : MonoBehaviour {

	public GameObject camara;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("Choque con " + col.gameObject.tag);
		if(col.gameObject.tag.Equals("techo"))
		{
			camara.SendMessage("Techo",SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{Debug.Log ("Choque con " + col.gameObject.tag);
		if(col.gameObject.tag.Equals("techo"))
		{
			camara.SendMessage("Techo",SendMessageOptions.DontRequireReceiver);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
