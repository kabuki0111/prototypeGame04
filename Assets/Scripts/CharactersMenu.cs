using UnityEngine;
using System.Collections;
using System.IO;

public class CharactersMenu : MonoBehaviour {

	private const float BUTTON_SIZE_X = 100;
	private const float BUTTON_SIZE_Y = 50;
	//Button back size
	private const float BUTTON_BACK_X = 200;
	private const float BUTTON_BACK_Y = 25;
	private const float BUTTON_POSITION_X = 100;
	private const float BUTTON_POSITION_Y = 100;
	
	//Setting GUIskin
	public GUISkin skin;	
	public Texture charTextA;
	public Texture charTextB;
	public Texture charTextC;
	
	//Button Charcter size
	public float CharSizeX = BUTTON_SIZE_X;
	public float CharSizeY = BUTTON_SIZE_Y;
	//Character Txet size
	public float TextSizeY = BUTTON_SIZE_Y; 
	//Button back size
	public float BackSizeX = BUTTON_BACK_X;
	public float BackSizeY = BUTTON_BACK_Y;
	//Button move position
	public float moveCharX = BUTTON_POSITION_X;	
	public float moveCharY = BUTTON_POSITION_Y;
	public float moveTextY = BUTTON_POSITION_Y;
	public float moveBackY = BUTTON_POSITION_Y;
	
	public bool character_switch = false;
	public bool lastmunu_switch = false;
	//Player character opnen flag
	public bool character_typeA_switch = false;
	public bool character_typeB_switch = false;
	public bool character_typeC_switch = false;
	private string witeA = "POWER : S \n"+"SPEED  : D \n"+"REACH  : D";
	private string witeB = "POWER : D \n"+"SPEED  : S \n"+"REACH  : A";
	private string witeC = "POWER : B \n"+"SPEED  : B \n"+"REACH  : B";	
	private string backText = "Back Title";

	void OnGUI()
	{
		GUI.skin = skin;
		
		if( character_switch != false )
		{
			TitleMenu titleSwitch = GetComponent( typeof(TitleMenu) ) as TitleMenu;
			CharactersLastCheckMunu lastCheckSwitch = GetComponent(typeof( CharactersLastCheckMunu) ) as CharactersLastCheckMunu;
		
			//Window center size
			float window_center_x = Screen.width / 2;
			float window_center_y = Screen.height / 2;
			//GUI center size
			float sizeX_center = CharSizeX / 2;
			float sizeY_center = CharSizeY / 2;
			float backX_center = BackSizeX / 2;
			float backY_center = BackSizeY / 2;
			//GUI button position setting
			float center_position_x = window_center_x - sizeX_center;
			float center_position_y = window_center_y - sizeY_center - moveCharY;
			float left_position_x = center_position_x - moveCharX;
			float right_position_x = center_position_x + moveCharX;
			float text_position_y = center_position_y + moveTextY;
			float back_position_x = window_center_x - backX_center;
			float back_position_y =window_center_y - backY_center + moveBackY;
		
			// GUI button position(Characters)
			Rect character_typeA =
				new Rect( left_position_x, center_position_y, CharSizeX, CharSizeY );
			Rect character_typeB =
				new Rect( right_position_x, center_position_y, CharSizeX, CharSizeY );
			Rect character_typeC =
				new Rect( center_position_x, center_position_y, CharSizeX, CharSizeY );
			//GUI charcater text
			Rect text_typeA =
				new Rect( left_position_x, text_position_y, CharSizeX, TextSizeY );
			Rect text_typeB =
				new Rect( right_position_x, text_position_y, CharSizeX, TextSizeY );
			Rect text_typeC =
				new Rect( center_position_x, text_position_y, CharSizeX, TextSizeY );
			//GUI Back button position
			Rect back_title =
				new Rect( back_position_x, back_position_y, BackSizeX, BackSizeY );
			
			GUI.Box( text_typeA, witeA );
			GUI.Box( text_typeB, witeB );
			GUI.Box( text_typeC, witeC );
			bool charcterA = GUI.Button( character_typeA, charTextA );
			bool charcterB = GUI.Button( character_typeB, charTextB );
			bool charcterC = GUI.Button( character_typeC, charTextC );
			bool back_button = GUI.Button( back_title, backText );
			
		
			//Charcter setting Menu
			if( charcterA )
			{
				//charcter type A chack
				PlayerPrefs.SetInt("Character", 0);
				character_switch = false;
				lastCheckSwitch.lastcheck_switch = true;
				Debug.Log("Charcter typeA setting");
			}
		
			if( charcterB )
			{
				//charcter type B chack
				PlayerPrefs.SetInt("Character", 1);
				character_switch = false;
				lastCheckSwitch.lastcheck_switch = true;
				Debug.Log("Charcter typeB setting");
			}
		
			if( charcterC )
			{
				//charcter type C chack
				PlayerPrefs.SetInt("Character", 2);
				character_switch = false;
				lastCheckSwitch.lastcheck_switch = true;
				Debug.Log("Charcter typeC setting");
			}
			
			//Back Title mune
			if( back_button )
			{
				titleSwitch.title_switch = true;
				character_switch = false;
			}
			
		}
		
	}

}
