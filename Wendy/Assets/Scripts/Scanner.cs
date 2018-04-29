using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections;

public class Scanner : MonoBehaviour
{
	TextTracker textTracker;

	[SerializeField]
	RectTransform tracker, detector;

	Rect displayTracker, displayDetect;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(WaitForTracker());
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if(textTracker != null)
		//{
		//	display2.sizeDelta += new Vector2(20.0f, 0) * Time.deltaTime;
		//	Rect regionOfInterestTracking = new Rect(display2.anchoredPosition, display2.sizeDelta);
		//	//Rect regionOfInterestDetection = new Rect(display2.anchoredPosition, display2.sizeDelta);
		//	textTracker.GetRegionOfInterest(out display, out display);
		//	textTracker.SetRegionOfInterest(display, regionOfInterestTracking);
		//}
		
	}

	private void Scan()
	{

	}

	IEnumerator WaitForTracker()
	{
		while (TrackerManager.Instance.GetTracker<TextTracker>() == null)
			yield return null;

		InitTracker();
	}

	void InitTracker()
	{
		TextTracker textTracker = (TextTracker)TrackerManager.Instance.GetTracker<TextTracker>();
		// text reco region of interest defined in screen coordinates:
		Rect regionOfInterestTracking = new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height));
		Rect regionOfInterestDetection = new Rect(Screen.width * 0.2f, Screen.height * 0.2f,
										  Screen.width * 0.6f, Screen.height * 0.2f);

		textTracker.SetRegionOfInterest(regionOfInterestDetection, regionOfInterestTracking);
		//detector.anchoredPosition = regionOfInterestDetection.position;
		//detector.sizeDelta = regionOfInterestDetection.size;
		//tracker.anchoredPosition = regionOfInterestTracking.position;
		//tracker.sizeDelta = regionOfInterestTracking.size;
	}

	void UpdateScannerWidth()
	{
		//display2.sizeDelta += new Vector2(20.0f, 0) * Time.deltaTime;
		//Rect regionOfInterestTracking = new Rect(display2.anchoredPosition, display2.sizeDelta);
		//Rect regionOfInterestDetection = new Rect(display2.anchoredPosition, display2.sizeDelta);

		//textTracker.SetRegionOfInterest(regionOfInterestDetection, regionOfInterestTracking);
	}
}
