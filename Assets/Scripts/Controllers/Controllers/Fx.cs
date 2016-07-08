using UnityEngine;
using System.Collections;

public class Fx : MonoBehaviour
{
    public AudioSource[] soundSource;              //Drag a reference to the audio source which will play the music.
    public static Fx instance = null;     //Allows other scripts to call functions from SoundManager.

    private bool muteState = false;


    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        //DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    public void PlaySingle(int clipindex)
    {
        if (!muteState)
        {
            soundSource[clipindex].Play();
        }
    }

    public void ToggleMute()
    {
        if (muteState)
        {
            DoUnmute();
        }
        else
        {
            DoMute();
        }
    }

    public void DoMute()
    {
        muteState = true;
        //playsource.Pause();
		//soundSource.volume = 0;
        //playsource.Stop();
    }

    public void DoUnmute()
    {
        muteState = false;
        //playsource.UnPause();
		//soundSource.volume = 10;
        //playsource.Play();
    }

	public void FullStop()
	{
		for (int i = 0; i < soundSource.Length; i++) {
			soundSource [i].Stop ();
		}
	}
}
