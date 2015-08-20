using UnityEngine;
using System.Collections;

public class Repisas : MonoBehaviour {

	public GameObject repisa1,repisa2,repisa3, techo;
	int contador, nivel;
	int tiempo;
	float ALTO_TECHO = 1;
	int TIEMPO_REPISAS;
	// Use this for initialization
	void Start () {
		TIEMPO_REPISAS = PlayerPrefs.GetInt ("trepisas");
		ALTO_TECHO = PlayerPrefs.GetFloat ("altura");
		tiempo = TIEMPO_REPISAS * 50;
		nivel = PlayerPrefs.GetInt("Nivel");
        techo.gameObject.transform.position = new Vector2(techo.gameObject.transform.position.x, techo.gameObject.transform.position.y +ALTO_TECHO);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //techo.gameObject.transform.position = new Vector2(techo.gameObject.transform.position.x, techo.gameObject.transform.position.y + nivel * ALTO_TECHO);
		if(tiempo==0)
			tiempo=50;
		if(contador%tiempo==0)
		{
			int repisasrandom = Random.Range(1,7);
			switch (repisasrandom)
			{
			case 1:
				repisa1.SetActive(false);
				repisa2.SetActive(false);
				repisa3.SetActive(false);
				break;
			case 2:
				repisa1.SetActive(true);
				repisa2.SetActive(true);
				repisa3.SetActive(false);
				break;
			case 3:
				repisa1.SetActive(true);
				repisa2.SetActive(false);
				repisa3.SetActive(true);
				break;
			case 4:
				repisa1.SetActive(false);
				repisa2.SetActive(true);
				repisa3.SetActive(true);
				break;
			case 5:
				repisa1.SetActive(true);
				repisa2.SetActive(false);
				repisa3.SetActive(false);
				break;
			case 6:
				repisa1.SetActive(false);
				repisa2.SetActive(true);
				repisa3.SetActive(false);
				break;
			case 7:
				repisa1.SetActive(false);
				repisa2.SetActive(false);
				repisa3.SetActive(true);
				break;
			}
		}
		contador++;
	
	}
}
