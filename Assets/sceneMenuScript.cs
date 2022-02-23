using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMenuScript : MonoBehaviour
{
    public playerScript ps;

    public void Start()
    {

    }
    public void playButton()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }

    public void partYard()
    {
        SceneManager.LoadScene(sceneName: "RocketParts");
    }

    public void addValue()
    {
        ps.addMoney(100);
    }

}
