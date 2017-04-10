using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Test2 : MonoBehaviour {
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClip;
	public RenderTexture renderTexture;
    int videoNo = 0;

	public void Start() {
		videoPlayer.clip = videoClip[0];
	}

    public void ChangeAspectRatio(string aspectRatio) {
        switch (aspectRatio) {
        case "NoScaling":
            videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
            break;
        case "FitVertically":
            videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
            break;
        case "FitHorizontally":
            videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
            break;
        case "FitInside":
            videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
            break;
        case "FitOutside":
            videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
            break;
        case "Stretch":
            videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
            break;
		}
        videoPlayer.Play();
	}

    public void ChangeVideo() {
        bool isPlaying = videoPlayer.isPlaying;
        videoNo = (videoNo+1) % 2;
        if (isPlaying) {
            videoPlayer.Stop();
        }
        videoPlayer.clip = videoClip[videoNo];
        if (isPlaying) {
            videoPlayer.Play();
        }
    }
}
