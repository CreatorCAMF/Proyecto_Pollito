//Este Script sirve para tomar las pociones iniciales y finales de un finger gesture,  y dibuja un onjeto (linea) en ese recorrido 
// OJO se debe tomar en cuenta la posicion de la camara, para cambiar las variables pertinentes
// En esta caso se uso un PhysicMaterial2D, y dependiendo de el largo del touch el rebote de dicho material cambia
// Perfecto para la creacion de ligas en dispositivos moviles =)
//Solo se genra una liga a la vez, y el tamaño es adaptable a la pantalla del dispositvo, pero su mejor funcionamiento se da en una pantalla WVGA de 480X800 en portrait
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Touches : MonoBehaviour {
	
	public GameObject trampolin, fantasma, trampolin2, fantasma2, trampolin3, fantasma3, tachuela;
    GameObject t1, t2, t3, t4, t5, t6;
	public PhysicsMaterial2D liga;
	public float MIN_REBOTE=.4f;
    bool pintatrampolin, pintafantasma, pintatrampolin2, pintafantasma2, pintatrampolin3, pintafantasma3;
	float pot;
    private Vector2 posLiga, posLiga2, posLiga3;

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 40, 20), "" + liga.bounciness);
	}

    private Vector2 startPos, startPos2, startPos3;

	// Use this for initialization
	void Start () {
		MIN_REBOTE = PlayerPrefs.GetFloat ("rebote");

	}
	
	// Update is called once per frame
	void Update () {
		FingerGestures ();
	
	}

	void FingerGestures()
	{
        if (Input.touchCount>0)
        {
            if(!pintatrampolin)
            {
                UnDedo();
            }
            else
            {
                if(!pintatrampolin2)
                {
                    DedoDos();
                }
                else
                {
                    if (!pintatrampolin3)
                    {
                        DedoTres();
                    }
                }
            }
        }
		


	}

    void UnDedo()
    {
        Touch touch = Input.touches[0];
        switch (touch.phase)
        {
            case TouchPhase.Began:
                startPos = touch.position;
                t1 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                if (pintatrampolin)
                {
                    trampolin.transform.position = new Vector2(10, 10);
                    pintatrampolin = false;
                }

                break;
            case TouchPhase.Moved:
                float swipeDistVerticalf = (new Vector3(0, touch.position.y) - new Vector3(0, startPos.y)).magnitude;
                float swipeDistHorizontalf = (new Vector3(touch.position.x, 0) - new Vector3(startPos.x, 0)).magnitude;
                float angulof = Mathf.Atan2((touch.position.y - startPos.y), (touch.position.x - startPos.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontalf, 2)) + (Mathf.Pow(swipeDistVerticalf, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                fantasma.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch.position.x > startPos.x)
                {
                    if (touch.position.y > startPos.y)
                    {
                        posLiga = new Vector2((((touch.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga = new Vector2((((touch.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch.position.y > startPos.y)
                    {
                        posLiga = new Vector2((((touch.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga = new Vector2((((touch.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                fantasma.gameObject.transform.position = posLiga;
                fantasma.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulof);

                break;
            case TouchPhase.Ended:

                //Establece la nueva liga.
                float swipeDistVertical = (new Vector3(0, touch.position.y) - new Vector3(0, startPos.y)).magnitude;
                float swipeDistHorizontal = (new Vector3(touch.position.x, 0) - new Vector3(startPos.x, 0)).magnitude;
                pintatrampolin = true;
                float angulo = Mathf.Atan2((touch.position.y - startPos.y), (touch.position.x - startPos.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontal, 2)) + (Mathf.Pow(swipeDistVertical, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                trampolin.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch.position.x > startPos.x)
                {
                    if (touch.position.y > startPos.y)
                    {
                        posLiga = new Vector2((((touch.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga = new Vector2((((touch.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch.position.y > startPos.y)
                    {
                        posLiga = new Vector2((((touch.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga = new Vector2((((touch.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                trampolin.gameObject.transform.position = posLiga;
                trampolin.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulo);
                t2 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                //Borra la liga fantasma
                if (pintatrampolin)
                {
                    fantasma.transform.position = new Vector2(10, 10);
                }
                
                break;

        }
    }

    void DedoDos()
    {
        Touch touch1 = Input.touches[0];
        switch (touch1.phase)
        {
            case TouchPhase.Began:
                startPos2 = touch1.position;
                t3 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                if (pintatrampolin2)
                {
                    trampolin2.transform.position = new Vector2(10, 10);
                    pintatrampolin2 = false;
                }

                break;
            case TouchPhase.Moved:
                float swipeDistVerticalf = (new Vector3(0, touch1.position.y) - new Vector3(0, startPos2.y)).magnitude;
                float swipeDistHorizontalf = (new Vector3(touch1.position.x, 0) - new Vector3(startPos2.x, 0)).magnitude;
                float angulof = Mathf.Atan2((touch1.position.y - startPos2.y), (touch1.position.x - startPos2.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontalf, 2)) + (Mathf.Pow(swipeDistVerticalf, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                fantasma2.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch1.position.x > startPos2.x)
                {
                    if (touch1.position.y > startPos2.y)
                    {
                        posLiga2 = new Vector2((((touch1.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch1.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga2 = new Vector2((((touch1.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch1.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch1.position.y > startPos2.y)
                    {
                        posLiga2 = new Vector2((((touch1.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch1.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga2 = new Vector2((((touch1.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch1.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                fantasma2.gameObject.transform.position = posLiga2;
                fantasma2.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulof);

                break;
            case TouchPhase.Ended:

                //Establece la nueva liga.
                float swipeDistVertical = (new Vector3(0, touch1.position.y) - new Vector3(0, startPos2.y)).magnitude;
                float swipeDistHorizontal = (new Vector3(touch1.position.x, 0) - new Vector3(startPos2.x, 0)).magnitude;
                pintatrampolin2 = true;
                float angulo = Mathf.Atan2((touch1.position.y - startPos2.y), (touch1.position.x - startPos2.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontal, 2)) + (Mathf.Pow(swipeDistVertical, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                trampolin2.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch1.position.x > startPos2.x)
                {
                    if (touch1.position.y > startPos2.y)
                    {
                        posLiga2 = new Vector2((((touch1.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch1.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga2 = new Vector2((((touch1.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch1.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch1.position.y > startPos2.y)
                    {
                        posLiga2 = new Vector2((((touch1.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch1.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga2 = new Vector2((((touch1.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch1.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                trampolin2.gameObject.transform.position = posLiga2;
                trampolin2.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulo);
                //Borra la liga fantasma2
                t4 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                if (pintatrampolin2)
                {
                    fantasma2.transform.position = new Vector2(10, 10);
                }
                break;

        }
    }

    void DedoTres()
    {
        Touch touch2 = Input.touches[0];
        switch (touch2.phase)
        {
            case TouchPhase.Began:
                startPos3 = touch2.position;
                t5 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                if (pintatrampolin3)
                {
                    trampolin3.transform.position = new Vector2(10, 10);
                    pintatrampolin3 = false;
                }

                break;
            case TouchPhase.Moved:
                float swipeDistVerticalf = (new Vector3(0, touch2.position.y) - new Vector3(0, startPos3.y)).magnitude;
                float swipeDistHorizontalf = (new Vector3(touch2.position.x, 0) - new Vector3(startPos3.x, 0)).magnitude;
                float angulof = Mathf.Atan2((touch2.position.y - startPos3.y), (touch2.position.x - startPos3.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontalf, 2)) + (Mathf.Pow(swipeDistVerticalf, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                fantasma3.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch2.position.x > startPos3.x)
                {
                    if (touch2.position.y > startPos3.y)
                    {
                        posLiga3 = new Vector2((((touch2.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch2.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga3 = new Vector2((((touch2.position.x - (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch2.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch2.position.y > startPos3.y)
                    {
                        posLiga3 = new Vector2((((touch2.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch2.position.y - (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga3 = new Vector2((((touch2.position.x + (swipeDistHorizontalf / 2)) * 6) / Screen.width), (((touch2.position.y + (swipeDistVerticalf / 2)) * 9) / Screen.height));
                    }
                }
                fantasma3.gameObject.transform.position = posLiga3;
                fantasma3.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulof);

                break;
            case TouchPhase.Ended:

                //Establece la nueva liga.
                float swipeDistVertical = (new Vector3(0, touch2.position.y) - new Vector3(0, startPos3.y)).magnitude;
                float swipeDistHorizontal = (new Vector3(touch2.position.x, 0) - new Vector3(startPos3.x, 0)).magnitude;
                pintatrampolin3 = true;
                float angulo = Mathf.Atan2((touch2.position.y - startPos3.y), (touch2.position.x - startPos3.x)) * Mathf.Rad2Deg;
                pot = Mathf.Sqrt((Mathf.Pow(swipeDistHorizontal, 2)) + (Mathf.Pow(swipeDistVertical, 2)));
                liga.bounciness = MIN_REBOTE + ((Screen.width - pot) / Screen.width);
                trampolin3.transform.localScale = new Vector3(pot * 3 / (Screen.width), 1f);

                if (touch2.position.x > startPos3.x)
                {
                    if (touch2.position.y > startPos3.y)
                    {
                        posLiga3 = new Vector2((((touch2.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch2.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga3 = new Vector2((((touch2.position.x - (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch2.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                else
                {
                    if (touch2.position.y > startPos3.y)
                    {
                        posLiga3 = new Vector2((((touch2.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch2.position.y - (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                    else
                    {
                        posLiga3 = new Vector2((((touch2.position.x + (swipeDistHorizontal / 2)) * 6) / Screen.width), (((touch2.position.y + (swipeDistVertical / 2)) * 9) / Screen.height));
                    }
                }
                trampolin3.gameObject.transform.position = posLiga3;
                trampolin3.gameObject.transform.rotation = Quaternion.Euler(0, 0, angulo);
                t6 = Instantiate(tachuela, new Vector3(startPos.x, startPos.y, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
                //Borra la liga fantasma3
                if (pintatrampolin3)
                {
                    fantasma3.transform.position = new Vector2(10, 10);
                }
                break;

        }
    }
    
    void PintarTrampolin1(bool p)
    {
        pintatrampolin = p;
    }

    void PintarTrampolin2(bool p)
    {
        pintatrampolin2 = p;
    }

    void PintarTrampolin3(bool p)
    {
        pintatrampolin3 = p;
    }


}
