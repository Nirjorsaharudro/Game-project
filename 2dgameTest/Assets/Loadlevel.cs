using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadlevel : MonoBehaviour
{
    public Animator transitions;
    public float transitionsTime;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            loadNextLevel();
        }
    }

    public void loadNextLevel(){
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        transitions.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTime);

        SceneManager.LoadScene(levelIndex);
    }
}
