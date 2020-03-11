using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTest : MonoBehaviour
{
    [Header("Shuffle")]
    [SerializeField, Tooltip("The shuffle value"), Range(0, 8)] private int setShuffle;
    [SerializeField] private AudioClip[] shuffleSounds;

    public static int shuffle;

    //Recently played sound index
    private int[] index;
    private int currentIndex = 0;

    [Header("Set Random Pitch Range")]
    [SerializeField, Tooltip("Pitch min value"), Range(-4, 1)] private float pitchMin;
    [SerializeField, Tooltip("Pitch max value"), Range(1, 4)] private float pitchMax;

   

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shuffle = setShuffle;
        //initializing index length to the same as shuffle
        index = new int[shuffle];

        //Setting all values in index to -1 at start. Done as a placeholder for an array value we will never have. 
        for (int i = 0; i < shuffle; i++) { index[i] = -1; }
    }

    public void playShuffle()
    {
        int soundPlaying;
        //The while loop cycles through the index checking for a previously played sound. If it finds one while loop starts again picking another random value. If not breaks from loop. 
        while (true)
        {
            soundPlaying = randomSound();
            bool foundSoundPlaying = false;
            for (int i = 0; i < shuffle; i++)
            {
                if (index[i] == soundPlaying) { foundSoundPlaying = true; }
            }
            if (!foundSoundPlaying) { break; }
        }
        index[currentIndex] = soundPlaying;
        Debug.Log(index[currentIndex]);
        currentIndex++;
        if (currentIndex == shuffle)
        {
            currentIndex = 0;
        }
        //Plays sound. Apparently this method is better as we made a variable and stored it rather than using a getter each time. 
        audioSource.clip = shuffleSounds[soundPlaying];
        audioSource.pitch = (Random.Range(pitchMin, pitchMax));
        audioSource.Play();
        //Resets currentIndex when it equals shuffle number


    }

    int randomSound()
    {

        int random = Random.Range(0, shuffleSounds.Length);
        return random;
    }

    void Update()
    {
        
    }
}
