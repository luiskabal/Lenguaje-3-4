using UnityEngine;
using System.Collections;

public class Android : MonoBehaviour {

    public void GoHome()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void GetOut()
    {
		Application.Quit ();
    }

}
