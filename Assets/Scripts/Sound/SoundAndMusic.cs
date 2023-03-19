using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    public static SoundAndMusic instance = null;

    public AudioClip ReactorDead;
    public AudioClip MathSirena;
    public AudioClip Ventil;
    public AudioClip ReactorGood;
    public AudioClip Polomka;

    private AudioSource Music;
    private AudioSource Background;


    void Start()
    {
        if (instance == null)
            instance = this;

        Music = transform.GetChild(0).GetComponent<AudioSource>();
        Background = transform.GetChild(1).GetComponent<AudioSource>();

    }


     public void KillReactor()
    {
        SoundManager.instance.PlaySingle(ReactorDead);
    }

    public void Mathematics()
    {
        SoundManager.instance.PlaySingle(MathSirena);
    }

    public void SpinCircle()
    {
        SoundManager.instance.PlaySingle(Ventil);
    }

    public void ReactorNice()
    {
        SoundManager.instance.PlaySingle(ReactorGood);
    }

    public void NewPolomka()
    {
        SoundManager.instance.PlaySingle(Polomka);
    }



}
