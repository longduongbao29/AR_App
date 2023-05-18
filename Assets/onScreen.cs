/*==============================================================================
Copyright (c) 2021 PTC Inc.
All Rights Reserved.
==============================================================================*/

using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class CustomTrackableEventHandler : DefaultObserverEventHandler
{
    private MediaPlayerVideoPlayer mediaPlayerVideoPlayer;

    protected override void Start()
    {
        base.Start();
        mediaPlayerVideoPlayer = GetComponentInChildren<MediaPlayerVideoPlayer>();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        if (mediaPlayerVideoPlayer != null)
        {
            mediaPlayerVideoPlayer.PlayVideo();
        }
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        if (mediaPlayerVideoPlayer != null)
        {
            mediaPlayerVideoPlayer.StopVideo();
        }
    }
}

public class MediaPlayerVideoPlayer : MonoBehaviour
{
    private Renderer quadRenderer;
    private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        quadRenderer = GetComponent<Renderer>();
        videoPlayer = GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.enabled = false;
        }
    }

    public void PlayVideo()
    {
        if (quadRenderer != null)
        {
            quadRenderer.enabled = true;
        }
        if (videoPlayer != null)
        {
            videoPlayer.enabled = true;
            videoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        if (quadRenderer != null)
        {
            quadRenderer.enabled = false;
        }
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.enabled = false;
        }
    }
}
