using System;
using UnityEngine;

public class AudioManager : MonoBehaviour                      //Audio singelton class
{
    private static AudioManager instance = null;
    public static AudioManager Instance{get{return instance;}}

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] diffSound;

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

    //````````````````````````````````````````````````````````````````````````````````````
    //````````````````````````````````````````````````````````````````````````````````````  
    private void Start() {

        //PlayMusic(Sounds.BGmusic);

    }

     //````````````````````````````````````````````````````````````````Play a certain Music
     //````````````````````````````````````````````````````````````````````````````````````
     internal void PlayMusic(Sounds requiredMusicType){

         AudioClip clip = getSoundClip(requiredMusicType);

         if(clip!=null){
             soundMusic.clip = clip;
             soundMusic.Play();                                                          //Play in Loop
         }
         else{
             Debug.Log("Clip Not Found");
         }

    }

    //`````````````````````````````````````````````````````````````````Play a Sound effect
    //````````````````````````````````````````````````````````````````````````````````````
    internal void Play(Sounds requiredSoundType){
        AudioClip clip = getSoundClip(requiredSoundType);
        if(clip!=null){
            soundEffect.PlayOneShot(clip);                                              //PlayOneShot - plays only once
        }
        else{
            Debug.Log("Clip not Found");
        } 
    }

    //```````````````````````find a certain Sound or music from diffSound array(of object) 
    //````````````````````````````````````````````````````````````````````````````````````
    private AudioClip getSoundClip(Sounds requiredSoundType){
        SoundType item = Array.Find(diffSound,i=>i.soundType==requiredSoundType);       //for each i(object) in array diffSound find the object with required soundType
        if(item!=null){
            return item.soundClip;                                                      //return the required sound clip according to requiredSoundType
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
    pickKey,
    damage,
    jump,
    doorOpen,
    grounded
}
