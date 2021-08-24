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
            s.audioSource = gameObject.AddComponent<AudioSource>();//���K�[component�F�A�̧ǧ�Sounds(Class)�̭����ܼ��Эȵ�component
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, aa => aa.name == name);///���j���ݸ��Ҧb�A�ثe�z�ѬOarray sounds�̭��R�W�@��aa,���aa.name���W�r�O�_��ǤJ��name�ȬۦP
        if(s == null)
        {
            Debug.LogWarning("����" + name + "�䤣��");
            return;
        }

        s.audioSource.Play();
    }

    

}
