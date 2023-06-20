using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text progressValueText;

    public void Awake() {
       progressPanel.SetActive(false); 
    }

    public void Loadlevel(string levelName){
        progressPanel.SetActive(true);
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while(!operation.isDone){
        float progress = Mathf.Clamp01(operation.progress);

        progressBar.value = progress;

        progressValueText.text = (progress * 100f).ToString("F0") + "%";
        Debug.Log(progress);
        yield return null;
        }
    }
}
