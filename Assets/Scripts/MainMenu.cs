using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public string startLevel;
	public string levelSelect;
	public int playerLives;
	public int playerHealth;

	public void NewGame ()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		Application.LoadLevel (this.startLevel);
	}

	public void LevelSelect ()
	{
		PlayerPrefs.SetInt ("PlayerCurrentLives", this.playerLives);
		PlayerPrefs.SetInt ("CurrentPlayerScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", this.playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", this.playerHealth);
		Application.LoadLevel (this.levelSelect);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
