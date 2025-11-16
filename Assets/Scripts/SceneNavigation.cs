using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation
{
    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}

public enum Scenes
{
    Menu = 0,
    Game = 1,
}