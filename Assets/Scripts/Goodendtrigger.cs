using UnityEngine;
using UnityEngine.SceneManagement;
public class Goodendtrigger : MonoBehaviour
{
    public int goodPoints = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goodPoints == 3) { SceneManager.LoadScene(sceneName: "Good"); }
    }

    public void SceneBegin()
    {
        SceneManager.LoadScene(sceneName: "MainScene");
    }

    public void gameQuit()
    {
        Application.Quit(0);
    }

}
