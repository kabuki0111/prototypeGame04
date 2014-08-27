using UnityEngine;
using System.Collections;

public class Player_TypeB : MonoBehaviour {
	private const int PLAYER_LIFE_POINT = 1;
	private const float PLAYER_SPEED = 1.0f;
	private const float BACK_MOVE=0.2f;
	private const float LIFET_AND_DOWN=0.01f;
	private const float RIGHT_AND_UP=1.00f;
	
	public int playerLife = PLAYER_LIFE_POINT;
	public float speed = PLAYER_SPEED;
	public float backMove = BACK_MOVE;

	public GameObject BulletTypeA;
	
// Update is called once per frame
	void Update () {
		Vector3 view_pos = Camera.main.WorldToViewportPoint(transform.position);
		
		//if player out lift and right camera
		if( view_pos.x < LIFET_AND_DOWN )
			transform.Translate(backMove, 0, 0);
		if( view_pos.x > RIGHT_AND_UP )
			transform.Translate(-backMove, 0, 0);
		//if player out up and down camera
		if( view_pos.y > RIGHT_AND_UP )
			transform.Translate(0, -backMove, 0);
    	if( view_pos.y < LIFET_AND_DOWN )
			transform.Translate(0, backMove, 0);		
			
		//player front and back key & player right and lofe key
		float front_back = Input.GetAxis("Vertical") * speed;
		front_back *= Time.deltaTime;
		float right_left = Input.GetAxis("Horizontal") * speed;
		right_left *= Time.deltaTime;
		
		//player typeA move now
		transform.Translate(right_left, front_back, 0);
		
		//Player Shot Key
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Shot SE
			//audio.Play();
			//Player's tama position
			Vector3 tama_position =
				new Vector3( transform.position.x, transform.position.y + 2.5f, transform.position.z );
			//Player's tama Instantiate
			Instantiate( BulletTypeA, tama_position, Quaternion.identity );
		}
	
	}
	
	
//Player's life point write windows
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 100, 20),"LIFE :"+playerLife);
	}
	

//Object hit Enter	
	private void OnCollisionEnter(Collision collision)
	{
		
		//If palyer hit Enemy
		if( (collision.gameObject.tag=="Enemy") )
		{	
			//life point one delete
			playerLife--;
		
			if(playerLife <= 0)
			{
				Debug.Log ("Player Hit!! gameover");
				Application.LoadLevel("Lose");
			}
		}
		
		//If palyer hit Enemy's tama
		if( ( collision.gameObject.tag=="EnemyTama" ) )
		{
			//life point one delete
			playerLife--;
			//Enemy's tama delete
			Destroy(collision.gameObject);
			
			if(playerLife <= 0)
			{
				Debug.Log ("Player Hit!! gameover");
				Application.LoadLevel("Lose");
			}
			
		}
		
	}
}