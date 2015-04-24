using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static int score;
	public Text text;

	public static void AddPoints (int pointsToAdd)
	{
		ScoreManager.score += pointsToAdd;
		PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
	}

	public static void Reset ()
	{
		ScoreManager.score = 0;
		PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
	}

	void Start ()
	{
		this.text = GetComponent<Text> ();

		//ScoreManager.score = 0;

		ScoreManager.score = PlayerPrefs.GetInt ("CurrentPlayerScore");
	}

	void Update ()
	{
		if (ScoreManager.score < 0) {
			ScoreManager.score = 0;
			PlayerPrefs.SetInt ("CurrentPlayerScore", ScoreManager.score);
		}

		this.text.text = "" + ScoreManager.score;
	}
}
