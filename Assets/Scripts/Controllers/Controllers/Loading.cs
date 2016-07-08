using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	public GameObject loadingCanvas;
	public GameObject background;
	public GameObject logo;
	public GameObject animated;
	public float fadeInTime = 1.0f;
	public float loadDelay = 1.0f;

	//private int loadProgress = 0;
	private AsyncOperation asynco;
	private string levelToLoad;

	// Use this for initialization
	void Start () 
	{
		

	}

	// Update is called once per frame
	void Update () 
	{

	}

	private void ObjectEnabler()
	{
		loadingCanvas.SetActive (true);
		background.SetActive (true);
		logo.SetActive (true);
		animated.SetActive (true);
		background.GetComponent<CanvasRenderer>().SetAlpha(0);
		logo.GetComponent<CanvasRenderer>().SetAlpha(0);
		foreach (Transform child in animated.transform) 
		{
			child.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);
		}
	}

	public void DoLoadLevel( string level )
	{
        Time.timeScale = 1;
        ObjectEnabler ();
		//FADER
		background.GetComponent<Image>().CrossFadeAlpha(1.0f,fadeInTime,false);
		logo.GetComponent<Image>().CrossFadeAlpha(1.0f,fadeInTime,false);
		foreach (Transform child in animated.transform) 
		{
			child.gameObject.GetComponent<Image>().CrossFadeAlpha(1.0f,fadeInTime,false);
		}
		levelToLoad = level;

		Invoke ("RealLoader",fadeInTime+0.1f);
	}

	private void RealLoader()
	{
        //Time.timeScale = 1.0F;
        StartCoroutine( DisplayLoadingScreen(levelToLoad) );
	}

	IEnumerator DisplayLoadingScreen( string level )
	{
		background.SetActive (true);
		logo.SetActive (true);
		animated.SetActive (true);

		//forced waiting
		yield return new WaitForSeconds(loadDelay);

		asynco = SceneManager.LoadSceneAsync(level);

		while (!asynco.isDone) 
		{
			yield return null;
		}
	}
}
