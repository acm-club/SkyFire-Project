using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	//GUI Elements
	public GUIText scoreText;
	public GUIText titleText;

	//Game Control Elements
	public static int score;
	public float gameOverWaitTime;

	//Main Routine
	void Start ()
	{
		titleText.text = "Sky Fire";
		score = 0;
		UpdateScore ();
	}

	//method to add points to total score
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	//Method used to update scoreText
	void UpdateScore ()
	{

		scoreText.text = "Score: " + score;
	}

	//Method for outside scripts to get the current score
	public static int GetScore()
	{
		return score;
	}

	//method to wait before moving to game over scene
	IEnumerator loadGameOver()
	{
		//waits before loading game over scene
		yield return new WaitForSeconds (gameOverWaitTime);

		//loads game over scene
		Application.LoadLevel (2);
		
	}
	
	//method that is triggered when the game ends
	public void GameOver ()
	{
		//transitions to the game over scene
		StartCoroutine (loadGameOver ());


		
		
		
	}
}