using UnityEngine;
using System.Collections;

public class LauncherScript : MonoBehaviour {
	
	public float angle;
	public float force;
	public int chicksLeft;
	public bool shoot1, shoot2;
	public float limitAngleUp;
	public float limitAngleDown;
	public float limitForceDown;
	public float limitForceUp;
	public float alternant = 1;

	void Start () {
		//alternant = PlayerPrefs.GetInt ("Dificultad");
        chicksLeft = PlayerPrefs.GetInt("PollosSalvados");
	}

	void Update () {
		if(!shoot1 && !shoot2){
			angle += alternant;
			if(angle < limitAngleDown){
				alternant *=-1;
			}
			if(angle > limitAngleUp){
				alternant *=-1;
			}
		}else if (!shoot1 && shoot2){
			force += alternant/2;
			if(force >= limitForceUp){
				alternant *=-1;
			}
			if(force <= limitForceDown){
				alternant *=-1;
			}
		}
		//float off = Input.GetAxis("Horizontal");
		//float off2 = Input.GetAxis("Vertical");
		//angle -= (off * 2);
		//force += (off2 / 2);
		//if (Input.GetKeyDown (KeyCode.Return)) {// Si le pica enter, reemplazar por entrada tactil
        if (Input.touchCount > 0) { 
            if(!shoot1 && !shoot2){
				shoot2 = true;
				if(alternant < 0){
					alternant*=-1;
				}
			}else if (!shoot1 && shoot2){
				shoot1 = true;
			}else{
				force =limitForceUp/2;
				shoot1 = false;
				shoot2 = false;
			}
		}
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 50), "Chicks Left: " + chicksLeft +"\n");
	}

	void ChickLess(){
		chicksLeft--;
	}

	void ChickUp(){
		chicksLeft++;
	}
}
