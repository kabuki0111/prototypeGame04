using UnityEngine;
using System.Collections;

public class Bullet_Normal : MonoBehaviour {
	public float shotspeed = 200.0f;
	public float pftlong = 100.0f;
	Transform playerget;

	
	public void Update () {
		Vector3 view_pos = Camera.main.WorldToViewportPoint(transform.position);
		
		//Camera out delete
		if(view_pos.y > 1.0f )
			Destroy(this.gameObject);
		
		// Player Object check
		playerget = GameObject.FindWithTag("Player").transform;
		
		Vector3 tamaspd = new Vector3(0, shotspeed, 0);
		transform.Translate(tamaspd * Time.deltaTime);
		
		// Tama Obj Delete  Longger Start
		if(Vector3.Distance(playerget.transform.position, this.transform.position) >= pftlong || (playerget==null) )
		{
			Destroy(this.gameObject);
		}
		
	}

}