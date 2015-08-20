using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillAmountArrow : MonoBehaviour {


	LauncherScript ls;
	GameObject chickenLauncher;
	Image im;
	float localForce;

	void Start () {
		chickenLauncher = GameObject.FindWithTag ("ChickenLauncher");
		ls = chickenLauncher.GetComponent<LauncherScript> ();
		im = GetComponent<Image> ();
	}

	void Update () {
		localForce = ls.force;
		im.fillAmount = localForce/ls.limitForceUp;
	}
}
