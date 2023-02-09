using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFiles : MonoBehaviour
{
    public List<AudioClip> audioClips= new List<AudioClip>();
    /*
     Kullanýrken :
    [SerializeField] private int musicNumber;
    private GameObject music;
    private MusicFiles musicFiles;

    music=GameObject.Find("AudioManager");
    musicFiles=_music.GetComponent(typeof(MusicFiles)) as MusicFiles;

    AudioSource.PlayClipAtPoint(musicFiles.music[musicNumber],gameObject.transform.position);
     */
}
