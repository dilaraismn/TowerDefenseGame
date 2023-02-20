using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource menuMusic, levelSelectMusic;
    public AudioSource[] bgm;
    public AudioSource[] sfx;
    private int currentBGM;
    private bool playingBGM;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playingBGM)
        {
            if (bgm[currentBGM].isPlaying == false)
            {
                currentBGM++;
                if (currentBGM >= bgm.Length)
                {
                    currentBGM = 0;
                }
                
                bgm[currentBGM].Play();
            }
        }
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        levelSelectMusic.Stop();

        foreach (AudioSource track in bgm)
        {
            track.Stop();
        }
        playingBGM = false;
    }
    
    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayLevelSelectMusic()
    {
        StopMusic();
        levelSelectMusic.Play();
    }

    public void PlayBGM()
    {
        StopMusic();
        currentBGM = Random.Range(0, bgm.Length);
        bgm[currentBGM].Play();
        playingBGM = true;
    }

    public void PlaySFX(int SFXToPlay)
    {
        sfx[SFXToPlay].Stop();
        sfx[SFXToPlay].Play();
    }
}
