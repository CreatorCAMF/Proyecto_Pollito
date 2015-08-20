using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public int diff = 5;
	public Text tdiff;

	public void ChangeToScene(string levelToLoad){
		Application.LoadLevel(levelToLoad);
	}

	public void SubirDiffic(){
		if(diff < 10){
			diff+=1;
			PlayerPrefs.SetInt("Dificultad",diff);
			PlayerPrefs.Save();
		}
	}
	
	public void BajarDiffic(){
		if(diff > 1){
			diff -= 1;
			PlayerPrefs.SetInt("Dificultad",diff);
			PlayerPrefs.Save();
		}
	}
	
	void Update(){
		tdiff.text = "Dificultad actual: "+ diff;
		/*if(Input.GetKeyDown(KeyCode.P)){
			PlayerPrefs.DeleteAll();
		}*/
	}
}
