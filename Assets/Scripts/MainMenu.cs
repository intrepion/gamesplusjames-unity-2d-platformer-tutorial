﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public string startLevel;
	public string levelSelect;

	public void NewGame ()
	{
		Application.LoadLevel (startLevel);
	}

	public void LevelSelect ()
	{
		Application.LoadLevel (levelSelect);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}
}
