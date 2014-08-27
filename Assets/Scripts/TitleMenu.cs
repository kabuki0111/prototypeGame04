using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour {

	private const float BUTTON_SIZE_X = 100;
	private const float BUTTON_SIZE_Y = 50;
	private const float BUTTON_POSITION_MOVE_Y = 10;
	
	//Setting GUIskin
	public GUISkin skin;
	
	public float sizeX = BUTTON_SIZE_X;
	public float sizeY = BUTTON_SIZE_Y;
	public float moveY = BUTTON_POSITION_MOVE_Y;
	
	public bool title_switch = true;
	
	void Start()
	{
		GameObject charcters = GameObject.FindWithTag("Player");
		charcters.SetActiveRecursively(false);
	}
	
	//Title menu
	void OnGUI()
	{
		//Setting GUIskin
		GUI.skin = skin;
		
		if( title_switch != false )
		{
			CharactersMenu characterSwitch =  GetComponent(typeof(CharactersMenu)) as CharactersMenu;
		
			//Window center size
			float window_center_x = Screen.width/2;
			float window_center_y = Screen.height/2;
			//GUI center size
			float sizeX_center = sizeX/2;
			float sizeY_center = sizeY/2;
		
			// GUI button position
			Rect game_start = new Rect( window_center_x - sizeX_center, window_center_y - sizeY_center + moveY, sizeX, sizeY );
			Rect game_option = new Rect( window_center_x - sizeX_center, window_center_y - sizeY_center + (moveY * 2), sizeX, sizeY );

			
			GUI.backgroundColor = Color.gray;
			bool start_button = GUI.Button( game_start,"Game start");
			bool option_button = GUI.Button( game_option, "Option");
		
			//Charcter setting Menu
			if( start_button )
			{
				characterSwitch.character_switch = true;
				title_switch = false;
				Debug.Log("Charcter setting");
			}
		
			// Game Option
			if( option_button )
			{
				Debug.Log("move option");
			}
			
		}

		
	}
}
