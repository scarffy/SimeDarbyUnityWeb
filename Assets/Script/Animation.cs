using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Animation : MonoBehaviour
{
    public PlayableDirector director;
    public PlayableAsset asset;

    public void PlayStop()
    {
        if (director.playableGraph.IsPlaying())
        {
            stop();
        }
        else if(!director.playableGraph.IsPlaying())
        {
            play();
        }
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
}
