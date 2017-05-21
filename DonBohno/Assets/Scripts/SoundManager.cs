using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour

{

    // Strings, die man übergeben kann zum abspielen: | kotzen | essen | hello | helicopter | wal | win |



    public AudioSource bg_musicSource;                 //Drag a reference to the audio source which will play the music.
    public AudioSource windSource;

    public AudioSource ShotSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource CollisionSource;
 


    public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    public AudioClip shot;
    public AudioClip collsision;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    //Used to play single sound clips.
    public void PlaySingle(string effectName)
    {
        if (effectName.Equals("shot"))
        {
            ShotSource.clip = shot;
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            ShotSource.pitch = randomPitch;
            ShotSource.Play();
        }
        else if (effectName.Equals("collision"))
        {
            CollisionSource.clip = collsision;
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            ShotSource.pitch = randomPitch;
            CollisionSource.Play();

        }
        
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        /*
        int randomIndex = Random.Range(0, clips.Length);

        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        essenSource.pitch = randomPitch;

        essenSource.clip = clips[randomIndex];

        essenSource.Play();
        */
    }
}