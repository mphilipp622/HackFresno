﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class StringParser : MonoBehaviour {

	private Dictionary<string, Vector3> wordPositions;
	private Dictionary<char, string> characterColors;
	private List<Color> randomColors;

	private List<string> words;

	[SerializeField]
	Text textWindow;

	void Start ()
	{
		words = new List<string>();
		wordPositions = new Dictionary<string, Vector3>();
		randomColors = new List<Color>();
		characterColors = new Dictionary<char, string>();

		GenerateRandomColors();
		SetColors();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void AddWord(string newWord, Vector3 pos)
	{
		if (wordPositions.ContainsKey(newWord))
			return;

		wordPositions.Add(newWord, pos );
	}

	public void ClearWords()
	{
		wordPositions.Clear();
		words.Clear();
	}

	public void DisplayText()
	{
		OrganizeWords();

		string output = null;
		foreach (string word in words)
		{
			for (int i = 0; i < word.Length; i++)
			{
				if (characterColors.ContainsKey(Char.ToUpper(word[i])))
					output += "<color=#" + characterColors[Char.ToUpper(word[i])] + ">" + word[i] + "</color>";
				else
					output += word[i];
			}

			output += " ";
		}

		textWindow.text = output;
	}

	private void OrganizeWords()
	{
		Dictionary<string, Vector3> subPositions = new Dictionary<string, Vector3>();

		while (wordPositions.Count > 0)
		{
			float highestY = wordPositions.Values.Max(v => v.y);

			foreach (KeyValuePair<string, Vector3> position in wordPositions)
			{
				if (position.Value.y <= (highestY + 5.0) && position.Value.y >= (highestY - 5.0))
					subPositions.Add(position.Key, position.Value); // Get relevant line first
			}

			while(subPositions.Count > 0)
			{
				float xMin = subPositions.Values.Min(v => v.x);
				string result = subPositions.First(v => v.Value.x == xMin).Key;

				if (subPositions.Count == 1)
					words.Add(result + "\n"); // handle new lines
				else
					words.Add(result);

				subPositions.Remove(result); // pop the result from sub positions.
				wordPositions.Remove(result); // remove item from old dict
			}
		}
	}

	void SetColors()
	{
		int maxColors = 26;

		for (int i = 0; i < maxColors; i++)
			characterColors.Add(Convert.ToChar(65 + i), ColorUtility.ToHtmlStringRGBA(randomColors[i]));

	}

	void GenerateRandomColors()
	{
		float newRed, newGreen, newBlue;
		

		for (int i = 0; i < 26; i++)
		{
			UnityEngine.Random.InitState(i);

			newRed = UnityEngine.Random.Range(0f, 1f);
			newGreen = UnityEngine.Random.Range(0f, 1f);
			newBlue = UnityEngine.Random.Range(0f, 1f);

			Color newColor = new Color(newRed, newGreen, newBlue, 1.0f);

			while (!IsThresholdSafe(newColor))
			{
				//Debug.Log("NOT SAFE");
				newRed = UnityEngine.Random.Range(0f, 1f);
				newGreen = UnityEngine.Random.Range(0f, 1f);
				newBlue = UnityEngine.Random.Range(0f, 1f);

				newColor = new Color(newRed, newGreen, newBlue, 1.0f);
			}

			randomColors.Add(newColor);
		}
		
	}

	bool IsThresholdSafe(Color newColor)
	{
		// Checks if the new color is too close in RGB value to any other color in the dictionary of colors
		float threshold = 0.1f;

		foreach (Color randomColor in randomColors)
		{
			float rDiff = newColor.r - randomColor.r;
			float gDiff = newColor.g - randomColor.g;
			float bDiff = newColor.b - randomColor.b;

			float totalDiff = (rDiff * rDiff + gDiff * gDiff + bDiff * bDiff);
			//Debug.Log(totalDiff);
			if (totalDiff <= threshold * threshold)
				return false;
		}

		return true;
	}
}
