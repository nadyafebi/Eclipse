using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitToChangeScene : MonoBehaviour
{
    public float waitTime;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
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
