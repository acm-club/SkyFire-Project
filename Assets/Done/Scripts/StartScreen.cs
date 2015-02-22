using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour
{

	public GUIText StartText;

	
	void Update ()
	{
			if (Input.GetKeyDown (KeyCode.Return))
			{
				Application.LoadLevel (1);
			}
	}
}