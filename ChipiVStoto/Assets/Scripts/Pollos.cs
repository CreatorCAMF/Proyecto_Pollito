using UnityEngine;
using System.Collections;

public class Pollos : MonoBehaviour {

	int POLLOS_INICALES=12;
	int pollos,pollossalvados=0,pollosmuertos=0;
	int TIEMPO_ENTRE_POLLOS=3;
	float tiempo;
	public GameObject pollo, copypollo;
	float VELOCIDAD_CAIDA=1;
	int contador;
	string frase;
	// Use this for initialization
	void Start () {
		TIEMPO_ENTRE_POLLOS = PlayerPrefs.GetInt ("taparicion");
		POLLOS_INICALES = PlayerPrefs.GetInt ("npollos");
		VELOCIDAD_CAIDA = PlayerPrefs.GetFloat ("vcaida");
		tiempo = TIEMPO_ENTRE_POLLOS * 50;
		pollos = POLLOS_INICALES;
        PlayerPrefs.SetInt("PollosMuertos", 0);
        PlayerPrefs.SetInt("PollosSalvados", 0);
        PlayerPrefs.Save();
		//PlayerPrefs.DeleteAll ();
	}

	void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			Application.LoadLevel("Testing");
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (100, 10, 100, 20), frase);
	}

	// Update is called once per frame
	void FixedUpdate () {
		pollosmuertos = PlayerPrefs.GetInt ("PollosMuertos");
		pollossalvados = PlayerPrefs.GetInt ("PollosSalvados");
		if(pollos>0)
		{
			if(tiempo==0)
				tiempo=50;
			if(contador%tiempo==0)
			{
				copypollo=Instantiate(pollo)as GameObject;
				copypollo.gameObject.rigidbody2D.gravityScale=VELOCIDAD_CAIDA;

				MenosPollos();
			}
		}
        if (pollosmuertos == POLLOS_INICALES)
		{
			frase="Has muerto";
		}
		else
		{
            if ((pollosmuertos + pollossalvados) == POLLOS_INICALES)
			{
                
				frase="siguiente tienes "+ pollossalvados+" pollos salvados";
				PlayerPrefs.SetInt("Nivel",PlayerPrefs.GetInt("Nivel")+1);
                PlayerPrefs.SetInt("npollos",PlayerPrefs.GetInt("PollosSalvados"));
				PlayerPrefs.Save();
                Application.LoadLevel("Test2");
			}
		}
		contador++;

	}

	/*void CambioDeTiempo(int segundos)
	{
		tiempo = segundos * 50;
	}*/


	void MasPollos()
	{
		pollos++;
	}

	void MenosPollos()
	{
		pollos--;

	}


}
