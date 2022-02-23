using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CartHandler : MonoBehaviour
{
    private PlayableDirector director;


    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        //director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        this.gameObject.SetActive(true);
    }

    //private void Director_Played(PlayableDirector obj)
    //{
    //    this.gameObject.SetActive(false);
    //}



}