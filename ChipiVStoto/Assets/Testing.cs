using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Testing : MonoBehaviour {

	public Text tvcaida,ttaparicion,tnpollos,taltura,ttrepisas,trebote;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void jugar()
	{
		Application.LoadLevel (1);
	}

	void vcaida()
	{
		PlayerPrefs.SetFloat("vcaida", float.Parse(tvcaida.text.ToString()));
		PlayerPrefs.Save ();
	}
	void taparicion()
	{
		PlayerPrefs.SetInt("taparicion", int.Parse(ttaparicion.text.ToString()));
		PlayerPrefs.Save ();
	}
	void npollos()
	{
		PlayerPrefs.SetInt("npollos", int.Parse(tnpollos.text.ToString()));
		PlayerPrefs.Save ();
	}
	void altura()
	{
		PlayerPrefs.SetFloat("altura", float.Parse(taltura.text.ToString()));
		PlayerPrefs.Save ();
	}
	void trepisas()
	{
		PlayerPrefs.SetInt("trepisas", int.Parse(ttrepisas.text.ToString()));
		PlayerPrefs.Save ();
	}
	void rebote()
	{
		PlayerPrefs.SetFloat("rebote", float.Parse(trebote.text.ToString()));
		PlayerPrefs.Save ();
	}

}
