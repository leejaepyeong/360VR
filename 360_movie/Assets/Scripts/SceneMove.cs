using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


// 각 장르의 영화 클립
[System.Serializable]
public class MovieClip
{
    public VideoClip[] videoClips;
}

public class SceneMove : MonoBehaviour
{
    public int SceneNumber; // 신 넘버
    public int movieGenre;   // 영화 장르
    // 0 : ACTION , 1 : HORROR , 2 : COMEDY , 3 : ANIMATION, 
    public bool isShow = true; // 상영중

    public GameObject[] movieGenrePanel;    // 영화 장르 패널

    public RawImage mScreen = null; // 영화  RawImage
    public VideoPlayer video = null;    //  비디오플레이어
    public MovieClip[] movieClips;  // 영화 장르
    AudioSource audio;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();
        audio = GetComponent<AudioSource>();

        StartCoroutine(PrepareVideo());
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

    protected IEnumerator PrepareVideo()
    {
        // 비디오 준비
        video.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!video.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다
        mScreen.texture = video.texture;
    }

    // 장르 속 몇번째 영화
    public void MovieBtn(int _num)
    {
        SceneNumber = _num;

        video.clip = movieClips[movieGenre].videoClips[SceneNumber];

        StartCoroutine(PrepareVideo());
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

    
    // 영화 정보보기
    public void MovieInfo()
    {

    }

}
