using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour {
	public VideoPlayer videoPlayer;
	public Slider alphaSlider;
	public RenderTexture renderTexture;
	public Renderer rendrer;
	public RawImage rawImage;
	int refreshCount = 0;

	void SetSendFrameReadyEvents(bool enable) {
		// 参考：http://stackoverflow.com/questions/42747285/getting-current-frame-from-videoplayer/42747609#42747609
		if (enable) {
			videoPlayer.sendFrameReadyEvents = true;
			videoPlayer.frameReady += OnNewFrame;
		} else {
			if (videoPlayer.sendFrameReadyEvents) {
				videoPlayer.frameReady -= OnNewFrame;
			}
			videoPlayer.sendFrameReadyEvents = false;
		}
	}

	void OnNewFrame(VideoPlayer source, long frameIdx)
	{
		refreshCount++;
		// 10フレームに1回更新する
		if (refreshCount >= 10) {
			rawImage.texture = source.texture;
			refreshCount = 0;
		}
	}

	void UpdateAlpha() {
		UpdateAlpha (alphaSlider.value);
	}

	void UpdateAlpha(float alpha) {
		videoPlayer.targetCameraAlpha = alpha;
	}

	public void PlayVideo(string mode) {
		UpdateAlpha ();
		switch (mode) {
		case "CameraFarPlane":
			SetSendFrameReadyEvents (false);
			videoPlayer.renderMode = VideoRenderMode.CameraFarPlane;
			break;
		case "CameraNearPlane":
			SetSendFrameReadyEvents (false);
			videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
			break;
		case "RenderTexture":
			SetSendFrameReadyEvents (false);
			videoPlayer.targetTexture = renderTexture;
			videoPlayer.renderMode = VideoRenderMode.RenderTexture;
			break;
		case "MaterialOverride":
			SetSendFrameReadyEvents (false);
			videoPlayer.targetMaterialRenderer = rendrer;
			videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
			break;
		case "APIOnly":
			SetSendFrameReadyEvents (true);
			videoPlayer.renderMode = VideoRenderMode.APIOnly;
			break;
		}
		videoPlayer.Play ();
	}

	public void Reset() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
