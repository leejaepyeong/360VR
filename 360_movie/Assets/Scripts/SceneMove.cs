using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public int SceneNumber; // 신 넘버
    public int movieGenre;   // 영화 장르
    // 0 : ACTION , 1 : HORROR , 2 : COMEDY , 3 : ANIMATION, 
    public bool isShow = true; // 상영중

    public GameObject[] movieGenrePanel;    // 영화 장르 패널

    public VideoPlayer video;
    AudioSource audio;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();
        audio = GetComponent<AudioSource>();
    }

    //영화 장르 고르기
    public void MovieGenreBtn(int _movieGenre)
    {
        movieGenre = _movieGenre;

        for (int i = 0; i < movieGenrePanel.Length; i++)
        {
            movieGenrePanel[i].SetActive(false);
        }
        movieGenrePanel[movieGenre].SetActive(true);

    }

    // 장르 속 몇번째 영화
    public void MovieBtn(int _num)
    {
        SceneNumber = _num;

        SceneManager.LoadScene("Movie" + movieGenre + "_" + SceneNumber);
    }

    // 재생 / 일시정지
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

    // 리셋
    public void ResetBtn()
    {
        video.time = 0f;
    }

    // 배속
    public void OnFastVideo(float speed)
    {
        video.playbackSpeed = speed;
    }

    
}
