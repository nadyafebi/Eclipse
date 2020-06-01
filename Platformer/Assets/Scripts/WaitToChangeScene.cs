using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class WaitToChangeScene : MonoBehaviour
{
    public string videoName;
    public float waitTime;
    public string nextScene;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
        videoPlayer.Play();
        StartCoroutine(ChangeAfterSeconds(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator ChangeAfterSeconds(float seconds)
    {
	yield return new WaitForSeconds(seconds);
	SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

}
