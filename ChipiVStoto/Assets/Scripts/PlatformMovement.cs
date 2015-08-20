using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {
	
	public bool horizontalX;
	public bool horizontalZ;
	public bool vertical;
	public bool circular;
	public float amplitud = 1;
	public float frecuencia = 1;
	
	float time = 0;
	
	void FixedUpdate () {
		if (horizontalX) {
			HorizontalX();
		}
		if(horizontalZ){
			HorizontalZ();
		}
		
		if (vertical) {
			Vertical();
		}
		if (circular) {
			Circular();
		}
		time += Time.deltaTime;
	}
	
	void Vertical(){
		Vector3 pos = this.transform.position;
		pos.y = this.transform.position.y + (amplitud * Mathf.Sin(time * frecuencia));
		this.transform.position = pos;
	}
	
	void HorizontalX(){
		Vector3 pos = this.transform.position;
		pos.x = this.transform.position.x + (amplitud * Mathf.Sin(time * frecuencia));
		this.transform.position = pos;
	}
	
	void HorizontalZ(){
		Vector3 pos = this.transform.position;
		pos.z = this.transform.position.z + (amplitud * Mathf.Sin(time * frecuencia));
		this.transform.position = pos;
	}
	
	void Circular(){
		float ang = this.transform.eulerAngles.y;
		ang += amplitud;
		this.transform.eulerAngles = new Vector3 (this.transform.eulerAngles.x, ang, this.transform.eulerAngles.z);
	}
}
