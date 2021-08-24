using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();//先添加component；再依序把Sounds(Class)裡面的變數覆值給component
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, aa => aa.name == name);///巨大的問號所在，目前理解是array sounds裡面命名一個aa,比對aa.name的名字是否跟傳入的name值相同
        if(s == null)
        {
            Debug.LogWarning("音效" + name + "找不到");
            return;
        }

        s.audioSource.Play();
    }

    

}
