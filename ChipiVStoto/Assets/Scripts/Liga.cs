using UnityEngine;
using System.Collections;

public class Liga : MonoBehaviour {


    public GameObject Camara;
	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionExit2D(Collision2D c)
	{
		this.transform.position = new Vector2 (10, 10);
        Camara.SendMessage("PintarTrampolin"+this.gameObject.transform.tag.ToString()+"", false, SendMessageOptions.DontRequireReceiver);
	}
}
