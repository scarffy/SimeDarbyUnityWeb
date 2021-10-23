using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Animation : MonoBehaviour
{
    public PlayableDirector director;


    public void PlayStop()
    {
        if (director.playableGraph.IsPlaying())
        {
            stop();
        }
        else
        {
            play();
        }
    }

    void play()
    {
        director.Play();
    }

    void stop()
    {
        director.Stop();
    }
}
