using System;
using UnityEngine;

public class AudioManager : MonoBehaviour                      //Audio singelton class
{
    private static AudioManager instance = null;
    public static AudioManager Instance{get{return instance;}}

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;

    //````````````````````````````````````````````````````````````````````````````````````
    //````````````````````````````````````````````````````````````````````````````````````
    
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    //```````````````````````````````````````````````````````````````Play a certain Sound
    //````````````````````````````````````````````````````````````````````````````````````

    internal void Play(Sounds sound){
        AudioClip clip = getSoundClip(sound);
        if(clip!=null){
            soundEffect.PlayOneShot(clip);                          //PlayOneShot - plays only once
        }
        else{
            Debug.Log("Clip not Found");
        } 
    }

    //`````````````````````````````````````````````````````````````````Get a certain Sound
    //````````````````````````````````````````````````````````````````````````````````````

    private AudioClip getSoundClip(Sounds sound){
        SoundType item = Array.Find(Sounds,i=>i.soundType==sound);    //for i in array SoundType find the index where it is stored
        if(item!=null){
            return item.soundClip;                                    //return the required sound clip according to sound Clip
        }
        return null;
    } 

}

//`````````````````````````````````````````````Array of SoundType with their SoundClip
//````````````````````````````````````````````````````````````````````````````````````
    
[Serializable]
public class SoundType{
    public Sounds soundType;
    public AudioClip soundClip;
}

//````````````````````````````````````````````````````````````Different type of Sound
//````````````````````````````````````````````````````````````````````````````````````

public enum Sounds{
    ButtonClick,
    PlayerDeath,
    PlayerMove,
    EnemyMove,
    BGmusic
}
