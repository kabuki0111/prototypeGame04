using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {
	public GameObject characterTypeA;
	public GameObject characterTypeB;
	public GameObject characterTypeC;

	void Awake ()
	{
		int characterType = PlayerPrefs.GetInt("Character");
		
		//Character load
		switch( characterType )
		{
		case 0:
			Instantiate(characterTypeA);
			break;
		case 1:
			Instantiate(characterTypeB);
			break;
		case 2:
			Instantiate(characterTypeC);
			break;
		}
		
		Destroy(gameObject);
	}

}
