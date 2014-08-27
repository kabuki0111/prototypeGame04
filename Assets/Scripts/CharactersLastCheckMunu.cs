using UnityEngine;
using System.Collections;

public class CharactersLastCheckMunu : MonoBehaviour {
	
	private const float BUTTON_BOX_X = 150;
	private const float BUTTON_BOX_Y = 100;
	private const float BUTTON_SIZE_X = 100;
	private const float BUTTON_SIZE_Y = 50;
	private const float BUTTON_MOVE_X = 20;
	private const float BUTTON_MOVE_Y = 120;
	
	//Setting GUIskin
	public GUISkin skin;
	
	//Button Last Check size
	public float boxSizeX = BUTTON_BOX_X;
	public float boxSizeY = BUTTON_BOX_Y;
	public float CharSizeX = BUTTON_BOX_X;
	public float CharSizeY = BUTTON_BOX_Y;
	public float lastButtonSizeX = BUTTON_SIZE_X;
	public float lastButtonSizeY = BUTTON_SIZE_Y;
	public float buttonMoveX = BUTTON_MOVE_X;
	public float buttonMoveY = BUTTON_MOVE_Y;
	public float aboutMoveX = BUTTON_MOVE_X;
	
	private string witeA = " Name / Natalia \n Nationality / USA \n Age / 30 \n height / 168.5cm \n weight / 60.4kg";
	private string witeB = " Name / Naomi \n Nationality / JAPAN \n Age / 20 \n height / 160.7cm \n weight / 48.8kg";
	private string witeC = " Name / Konoha \n Nationality / JAPAN \n Age / 18 \n height / 157.2cm \n weight / 42.8kg";	
	
	public bool lastcheck_switch = false;
	
	void Start()
	{
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		
		if( lastcheck_switch != false )
		{
			int characterType = PlayerPrefs.GetInt("Character");
			CharactersMenu characterSwitch =  GetComponent(typeof(CharactersMenu)) as CharactersMenu;
			
			//Window center size
			float window_center_x = Screen.width / 2;
			float window_center_y = Screen.height / 2;
			float boxX_center = boxSizeX/2;
			float boxY_center = boxSizeY/2;
			float sizeX_center = lastButtonSizeX / 2;
			float sizeY_center = lastButtonSizeY / 2;
			
			float lastcheckBox_position_x = window_center_x - boxX_center;
			float lastchackBox_position_y = window_center_y -boxY_center;
			float lastcheck_position_x = window_center_x - sizeX_center;
			float lastcheck_position_y = window_center_y - sizeY_center + buttonMoveY;
			
			//GUI Character Box position
			Rect CharAbout_Box =
				new Rect(lastcheckBox_position_x - aboutMoveX, lastButtonSizeY, CharSizeX, CharSizeY);
			//GUI Box position
			Rect lastCheck_Box =
				new Rect(lastcheckBox_position_x, lastchackBox_position_y + buttonMoveY, boxSizeX, boxSizeY );
			//GUI button position
			Rect lastcheck_yes =
				new Rect( lastcheck_position_x - buttonMoveX, lastcheck_position_y, lastButtonSizeX, lastButtonSizeY );
			Rect lastcheck_no =
				new Rect( lastcheck_position_x + buttonMoveX, lastcheck_position_y, lastButtonSizeX, lastButtonSizeY );
			
			//BOX write
			GUI.Box(lastCheck_Box, "Are you okay?");
			bool button_yes = GUI.Button( lastcheck_yes, "YES!!" );
			bool button_no = GUI.Button( lastcheck_no, "NO!!" );
			
			switch(characterType)
			{
			case 0:
				GUI.color = Color.green;
				GUI.Label( CharAbout_Box, witeA );
				break;
			case 1:
				GUI.color = Color.green;
				GUI.Label( CharAbout_Box, witeB );
				break;
			case 2:
				GUI.color = Color.green;
				GUI.Label( CharAbout_Box, witeC );
				break;
			}
			
			//Last Check Button yes or no?
			if( button_yes )
			{
				iTween.FadeTo(gameObject, iTween.Hash("alpha", 1, "time", 0.5f));
				lastcheck_switch = false;
				Application.LoadLevel("GameScene");
			}
			if( button_no )
			{
				lastcheck_switch = false;
				characterSwitch.character_switch = true;
			}
			
		}//*Last Check End*
	
	}
}
