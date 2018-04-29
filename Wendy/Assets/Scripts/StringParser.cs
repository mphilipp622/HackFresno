using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class StringParser : MonoBehaviour {

	private Dictionary<string, Vector3> wordPositions;
	private Dictionary<char, string> characterColors;
	private List<Color> randomColors;
	List<Color> pastels;

	private List<string> words;

	[SerializeField]
	Text textWindow;

	[SerializeField]
	Image background;

	void Start ()
	{
		words = new List<string>();
		wordPositions = new Dictionary<string, Vector3>();
		randomColors = new List<Color>();
		characterColors = new Dictionary<char, string>();
		pastels = new List<Color>();

		InitPastels();
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

			newRed = UnityEngine.Random.Range(0f, 1f);
			newGreen = UnityEngine.Random.Range(0f, 1f);
			newBlue = UnityEngine.Random.Range(0f, 1f);

			Color newColor = new Color(newRed, newGreen, newBlue, 1.0f);

			while (!IsThresholdSafe(newColor))
			{

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
		float threshold = 0.35f;

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

	private Color GetNewColor(int r, int g, int b)
	{
		return new Color(r / 255f, g / 255f, b / 255f, 1.0f);
	}

	private Color GetNewColor(uint hexVal)
	{
		Byte[] bytes = BitConverter.GetBytes(hexVal);

		float newR = Convert.ToInt32(bytes[3]) / 255f;
		float newG = Convert.ToInt32(bytes[2]) / 255f;
		float newB = Convert.ToInt32(bytes[1]) / 255f;

		//Debug.Log(newR + ", " + newG + ", " + newB);
		return new Color(newR, newG, newB, 1f);
	}

	void InitPastels()
	{
		pastels.Add(GetNewColor(0xfffaf000));
		pastels.Add(GetNewColor(0xfdf5e600));
		pastels.Add(GetNewColor(0xfaf0e600));
		pastels.Add(GetNewColor(0xfaebd700));
		pastels.Add(GetNewColor(0xcdc0b000));
		pastels.Add(GetNewColor(0xeedfcc00));
		pastels.Add(GetNewColor(0xffefd500));
		pastels.Add(GetNewColor(0xffebcd00));
		pastels.Add(GetNewColor(0xffe4c400));
		pastels.Add(GetNewColor(0xeed5b700));
		pastels.Add(GetNewColor(0xcdb79e00));
		pastels.Add(GetNewColor(0xffdead00));
		pastels.Add(GetNewColor(0xffe4b500));
		pastels.Add(GetNewColor(0xfff8dc00));
		pastels.Add(GetNewColor(0xeee8dc00));
		pastels.Add(GetNewColor(0xcdc8b100));
		pastels.Add(GetNewColor(0xfffff000));
		pastels.Add(GetNewColor(0xeeeee000));
		pastels.Add(GetNewColor(0xfffacd00));
		pastels.Add(GetNewColor(0xfff5ee00));
		pastels.Add(GetNewColor(0xeee5de00));
		pastels.Add(GetNewColor(0xf0fff000));
		pastels.Add(GetNewColor(0xe0eee000));
		pastels.Add(GetNewColor(0xc1cdc100));
		pastels.Add(GetNewColor(0xf5fffa00));
		pastels.Add(GetNewColor(0xf0ffff00));
		pastels.Add(GetNewColor(0xf0f8ff00));
		pastels.Add(GetNewColor(0xe6e6fa00));
		pastels.Add(GetNewColor(0xfff0f500));
		pastels.Add(GetNewColor(0xffe4e100));

		background.color = pastels[UnityEngine.Random.Range(0, pastels.Count - 1)]; // randomize initial background color
	}

	public void SwapBackgroundColor()
	{
		background.color = pastels[UnityEngine.Random.Range(0, pastels.Count - 1)];
	}

	public void SwapFontColor()
	{
		// swaps to a new color theme
		randomColors.Clear();
		characterColors.Clear();

		textWindow.text = "";
		GenerateRandomColors();
		SetColors();

		DisplayText();
	}
}
