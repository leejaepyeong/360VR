using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public int SceneNumber; // �� �ѹ�
    public int movieGenre;   // ��ȭ �帣
    // 0 : ACTION , 1 : HORROR , 2 : COMEDY , 3 : ANIMATION, 
    public bool isShow = true; // ����

    public GameObject[] movieGenrePanel;    // ��ȭ �帣 �г�

    public VideoPlayer video;
    AudioSource audio;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();
        audio = GetComponent<AudioSource>();
    }

    //��ȭ �帣 ����
    public void MovieGenreBtn(int _movieGenre)
    {
        movieGenre = _movieGenre;

        for (int i = 0; i < movieGenrePanel.Length; i++)
        {
            movieGenrePanel[i].SetActive(false);
        }
        movieGenrePanel[movieGenre].SetActive(true);

    }

    // �帣 �� ���° ��ȭ
    public void MovieBtn(int _num)
    {
        SceneNumber = _num;

        SceneManager.LoadScene("Movie" + movieGenre + "_" + SceneNumber);
    }

    // ��� / �Ͻ�����
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

    // ����
    public void ResetBtn()
    {
        video.time = 0f;
    }

    // ���
    public void OnFastVideo(float speed)
    {
        video.playbackSpeed = speed;
    }

    
}
