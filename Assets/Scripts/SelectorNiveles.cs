using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SelectorNiveles : MonoBehaviour
{
    public void buttonVolver()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Level1()
   {
        SceneManager.LoadScene("lvl1cutscene");
   }

    public void Level2()
    {
        SceneManager.LoadScene("lvl2cutscene");
    }
    public void Level3()
    {
        SceneManager.LoadScene("lvl4cutscene");
    }

    public void Level4()
    {
        SceneManager.LoadScene("lvl5custscene");
    }

    public void Level5()
    {
        SceneManager.LoadScene("lvl3cutscene");
    }

}
