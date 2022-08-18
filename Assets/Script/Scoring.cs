using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public float gemMothership;
    public GameObject UIGem;
    public GameObject UIPause;
    

    // Update is called once per frame
    void Update()
    {
        gemMothership = PlayerPrefs.GetInt("gemMothership");
        UIGem.GetComponent<UnityEngine.UI.Text>().text = gemMothership.ToString();

        if(Input.GetKeyDown("escape")){
            Time.timeScale = 0;
            UIPause.SetActive(true);
        }
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        UIPause.SetActive(false);
    }

    public void ExitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
