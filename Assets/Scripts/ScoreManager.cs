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
	}

	public static void Reset ()
	{
		ScoreManager.score = 0;
	}

	void Start ()
	{
		this.text = GetComponent<Text> ();

		ScoreManager.score = 0;
	}

	void Update ()
	{
		if (ScoreManager.score < 0) {
			ScoreManager.score = 0;
		}

		this.text.text = "" + ScoreManager.score;
	}
}
