using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	//GUI Elements
	public GUIText RestartText;
	public GUIText GameOverText;
	public GUITexture UnityLogo;

	//Control Elements
	public bool GameOverController = true;


	void Update ()
	{
		//toggles unity logo off or on with R
		if (Input.GetKeyDown (KeyCode.R))
		{
			if(GameOverController)
			{
				UnityLogo.guiTexture.enabled = false;
				GameOverController = false;
			}

			else
			{
				UnityLogo.guiTexture.enabled = true;
				GameOverController = true;

			}


		}



		//displays score text
		GameOverText.text = "Game Over \n\n High Score: " + GameController.GetScore()
			+"\n Score: " + GameController.GetScore();


		// displays instructions to restart
		RestartText.text = "Press Enter to Restart Game";

		//loads start screen if enter is pressed
		if (Input.GetKeyDown (KeyCode.Return))
		{
			Application.LoadLevel (0);
		}
	}
}