using UnityEngine;
using System.Collections;

public class PolloFisicas : MonoBehaviour {

	Vector2 posisionInicial;
	public Vector2 posicionactual;
	// Use this for initialization
	void Start () {

		this.gameObject.rigidbody2D.AddForce (new Vector2(Random.value+.1f*2, 0),  ForceMode2D.Impulse);
		posisionInicial = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		posicionactual = new Vector2 (this.gameObject.transform.position.x, this.gameObject.transform.position.y);
	
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag.Equals("Sarten"))
		{
			PlayerPrefs.SetInt("PollosMuertos",PlayerPrefs.GetInt("PollosMuertos")+1);
			PlayerPrefs.Save();
			Destroy(this.gameObject);

		}
		if(c.gameObject.tag.Equals("Meta"))
		{
			PlayerPrefs.SetInt("PollosSalvados",PlayerPrefs.GetInt("PollosSalvados")+1);
			PlayerPrefs.Save();
			Destroy(this.gameObject);
		}
	}
}
