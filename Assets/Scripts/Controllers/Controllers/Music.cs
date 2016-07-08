using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour
{
    public AudioClip[] musicSource;          //Drag a reference to the audio source which will play the music.
    public static Music instance = null;     //Allows other scripts to call functions from SoundManager.

    private bool muteState = false;
    private AudioSource playsource;
    private bool isPlaying;

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

    void Start()
    {
        playsource = gameObject.GetComponent<AudioSource>();
        isPlaying = false;
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        if (!muteState)
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            playsource.clip = clip;
            //Play the clip.
            playsource.Play();
            isPlaying = true;
        } 
    }

    public void PlaySingle(int clipindex)
    {
        if (!muteState)
        {
            //Set the clip of our efxSource audio source to the clip passed in as a parameter.
            playsource.clip = musicSource[clipindex];
            //Play the clip.
            playsource.Play();
            isPlaying = true;
        }
    }

    public void StopMusic()
    {
        playsource.Stop();
        isPlaying = false;
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
        playsource.Pause();
        //playsource.volume = 0;
        //playsource.Stop();
    }

    public void DoUnmute()
    {
        muteState = false;
        playsource.UnPause();
        //playsource.volume = 10;
        //playsource.Play();
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }
}