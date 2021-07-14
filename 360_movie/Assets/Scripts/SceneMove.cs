using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


// movie genre clip
[System.Serializable]
public class MovieClip
{
    public VideoClip[] videoClips;
}

public class SceneMove : MonoBehaviour
{
    public int SceneNumber; // scene Number
    public int movieGenre;   // movie genre
    // 0 : ACTION , 1 : HORROR , 2 : COMEDY , 3 : ANIMATION, 
    public bool isShow = true; // movie show

    public GameObject[] movieGenrePanel;    // 4 genre panel

    public RawImage mScreen = null; // screen  RawImage
    public VideoPlayer video = null;    //  movie video
    public MovieClip[] movieClips;  // movie clip

    public GameObject[] processVolumeEffect;   // processVolume

    AudioSource audio;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();
        audio = GetComponent<AudioSource>();

        StartCoroutine(PrepareVideo());
    }

    //change movie genre
    public void MovieGenreBtn(int _movieGenre)
    {
        movieGenre = _movieGenre;

        for (int i = 0; i < movieGenrePanel.Length; i++)
        {
            movieGenrePanel[i].SetActive(false);
        }
        movieGenrePanel[movieGenre].SetActive(true);

    }

    // movie prepare
    protected IEnumerator PrepareVideo()
    {
        // ready
        video.Prepare();

        // ready on
        while (!video.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer scene texture = RawImage texture
        mScreen.texture = video.texture;
    }

    // choose movie clip
    public void MovieBtn(int _num)
    {
        SceneNumber = _num;

        video.clip = movieClips[movieGenre].videoClips[SceneNumber];

        StartCoroutine(PrepareVideo());
    }

    // play and pause button
    public void StopBtn()
    {
        isShow = !isShow;

        if (isShow)
        {
            video.Play();
        }
        else
        {
            video.Pause();
        }
            
    }

    // reset button
    public void ResetBtn()
    {
        video.time = 0f;
    }

    // change speed
    public void OnFastVideo(float speed)
    {
        video.playbackSpeed = speed;
    }

    
    // movie Info
    public void MovieInfoBtn()
    {

    }

    public void ChangeVolume(int _num)
    {
        foreach(GameObject volume in processVolumeEffect)
        {
            volume.SetActive(false);
        }

        processVolumeEffect[_num].SetActive(true);
    }

}
