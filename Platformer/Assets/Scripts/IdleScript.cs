using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleScript : MonoBehaviour
{
    public string IdleEnding;

    IEnumerator Wait(float idleDuration)
    {
	yield return new WaitForSeconds(idleDuration);
	SceneManager.LoadScene(IdleEnding);
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(15.0f));

	
    }

    // Update is called once per frame
    void Update()
    {
    }

}
