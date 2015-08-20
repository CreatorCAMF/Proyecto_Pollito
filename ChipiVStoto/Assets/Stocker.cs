using UnityEngine;
using System.Collections;
using System;

public class Stocker : MonoBehaviour {

	GameObject [] pollos;
	Vector3 posicioninicial;
	bool techo=false;
	// Use this for initialization
	void Start () {
	
		posicioninicial = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		/*pollos = GameObject.FindGameObjectsWithTag ("Pollos");
		for (int i=0; i<pollos.Length; i++) {
			PolloFisicas pollo = pollos[i].GetComponent<PolloFisicas>();
			//Debug.Log(i+"    "+pollo.gameObject.transform.position.y);
			if(pollo.gameObject.transform.position.y>10f)
			{
				if(!techo)
				{
					this.gameObject.transform.position=new Vector3(this.gameObject.transform.position.x,pollo.gameObject.transform.position.y-5f,-10);
				}
			}
			else
			{
				this.gameObject.transform.position=posicioninicial;
			}
		}*/
        BuscarYSeguirAlPolloMasCercaDelSuelo();
	}

    void BuscarYSeguirAlPolloMasCercaDelSuelo()
    {
        pollos = GameObject.FindGameObjectsWithTag("Pollos");
        if(pollos.Length>0)
        {
            float[] altura = new float[pollos.Length];
            float[] ordenados = new float[pollos.Length];
            for (int i = 0; i < pollos.Length; i++)
            {

                PolloFisicas pollo = pollos[i].GetComponent<PolloFisicas>();
                altura[i] = pollo.gameObject.transform.position.y;
                ordenados[i] = pollo.gameObject.transform.position.y;
            }
            Array.Sort(ordenados);
            int pos = (Array.FindIndex(altura, p => p == ordenados[0]));
            PolloFisicas polloF = pollos[pos].GetComponent<PolloFisicas>();
            if (polloF.gameObject.transform.position.y > 9.5)
            {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 5+(polloF.transform.position.y-9.5f), -10);
            }
            else
            {
                this.gameObject.transform.position = posicioninicial;
            }
        }
        else
        {
            this.gameObject.transform.position = posicioninicial;
        }
        
        
        
        
    }

	void Techo()
	{
		techo = !techo;
	}
}
