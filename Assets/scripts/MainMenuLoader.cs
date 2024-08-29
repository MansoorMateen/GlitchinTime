using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
 void Start()
{
    //Start the coroutine we define below named ChangeAfter2SecondsCoroutine().
    StartCoroutine(ChangeAfter2SecondsCoroutine());
}

IEnumerator ChangeAfter2SecondsCoroutine()
{
    //Print the time of when the function is first called.
    Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //yield on a new YieldInstruction that waits for 5 seconds.
    yield return new WaitForSeconds(2);

    //After we have waited 2 seconds print the time again.
    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    //And load the scene
        SceneManager.LoadScene("MainMenu");
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
