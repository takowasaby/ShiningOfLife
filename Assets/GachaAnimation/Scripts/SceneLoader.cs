using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private TermProgress termProgress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneTerm()
    {
        if (termProgress.currentTerm < 12)
        {
            LoadScene("GachaEdit");
        }else
        {
            LoadScene("ShortResult");
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
