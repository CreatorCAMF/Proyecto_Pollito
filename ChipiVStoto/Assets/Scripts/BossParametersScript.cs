using UnityEngine;
using System.Collections;

public class BossParametersScript : MonoBehaviour {

	//Script that controls the parameters recieved by the boss, like difficulty and then controls the life of the boss
	public bool isAlive;
	public float Max_life;
	public float CurrentLife;
	public int diffic = 1;
	GameObject chickenLauncher;
	BossStarsAnimator bsa;
	LauncherScript ls;
	public float SaveWaitTime = 3.0f;
	
	void Start () {
		chickenLauncher = GameObject.FindWithTag("ChickenLauncher");
		if(chickenLauncher!= null){
			ls = chickenLauncher.GetComponent<LauncherScript>();
		}
		diffic = PlayerPrefs.GetInt ("Dificultad");
        if(diffic < 1)
        {
            diffic = 1;
        }
		Max_life = 9 + diffic;
		CurrentLife = Max_life;
		isAlive = true;
		bsa = GetComponentInChildren<BossStarsAnimator>();
	}
	
	void Update () {
		if(CurrentLife <= 0){
			isAlive = false;
			StartCoroutine("SaveChickens");
		}
	}
	
	void LifeLess(float dmg){ //Cambiar float por entero
		if(CurrentLife - dmg > 0){
			CurrentLife -= dmg;
		}else{
			CurrentLife = 0;
			bsa.SendMessage("ActivateStars");
		}
	}
	
	IEnumerator SaveChickens(){
	yield return new WaitForSeconds(SaveWaitTime);
		if(ls!= null){
			int chicksToSave = ls.chicksLeft;
			PlayerPrefs.SetInt("PollosSalvados",chicksToSave);
			PlayerPrefs.Save();
			/*To DO: que el gato le avise a el manager que ya esta muerto y la escena debe proseguir*/
			//Debug.Log("Pollos Salvados:"+ chicksToSave);
		}
	}
	
	void OnGUI(){//Para testing
		GUI.Label (new Rect (0, 100, 100, 50), "Boss Life:" + CurrentLife);
	}
}
