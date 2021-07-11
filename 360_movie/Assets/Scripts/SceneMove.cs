using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


// �� �帣�� ��ȭ Ŭ��
[System.Serializable]
public class MovieClip
{
    public VideoClip[] videoClips;
}

public class SceneMove : MonoBehaviour
{
    public int SceneNumber; // �� �ѹ�
    public int movieGenre;   // ��ȭ �帣
    // 0 : ACTION , 1 : HORROR , 2 : COMEDY , 3 : ANIMATION, 
    public bool isShow = true; // ����

    public GameObject[] movieGenrePanel;    // ��ȭ �帣 �г�

    public RawImage mScreen = null; // ��ȭ  RawImage
    public VideoPlayer video = null;    //  �����÷��̾�
    public MovieClip[] movieClips;  // ��ȭ �帣
    AudioSource audio;

    private void Start()
    {
        video = GetComponentInChildren<VideoPlayer>();
        audio = GetComponent<AudioSource>();

        StartCoroutine(PrepareVideo());
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

    protected IEnumerator PrepareVideo()
    {
        // ���� �غ�
        video.Prepare();

        // ������ �غ�Ǵ� ���� ��ٸ�
        while (!video.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer�� ��� texture�� RawImage�� texture�� �����Ѵ�
        mScreen.texture = video.texture;
    }

    // �帣 �� ���° ��ȭ
    public void MovieBtn(int _num)
    {
        SceneNumber = _num;

        video.clip = movieClips[movieGenre].videoClips[SceneNumber];

        StartCoroutine(PrepareVideo());
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

    
    // ��ȭ ��������
    public void MovieInfo()
    {

    }

}
