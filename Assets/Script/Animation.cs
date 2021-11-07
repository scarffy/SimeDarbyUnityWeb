using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    public PlayableDirector director;
    public PlayableAsset asset;

    [Space, SerializeField] bool isPlaying = true;

    [Space]
    public Image icon;
    public Sprite playIcon;
    public Sprite pauseIcon;


    private void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    private void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }

    public void PlayStop()
    {
        if (isPlaying)
        {
            stop();
            isPlaying = false;
        }
        else
        {
            play();
            isPlaying = true;
        }
        icon.sprite = isPlaying ? playIcon : pauseIcon;
    }

    void play()
    {
        director.Play(asset);
    }

    void stop()
    {
        director.playableGraph.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            play();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            stop();
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            director.playableGraph.Stop();
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
            isPlaying = false;
    }
}
