using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaEnd : MonoBehaviour
{
    public GameObject options;
    public GameObject vape;
    public TextMeshProUGUI convo;
    int x = 0;
    int y;
    string[] lines;
    public string con;

    void Start()
    {
        lines = System.IO.File.ReadAllLines(con);
        y = lines.Length;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (x == y)
            {
                convo.text = "Play again?";
                options.SetActive(true);
            }

            if (x < y)
            {
                convo.text = lines[x];
                x++;
            }

            if (x == 2){vape.SetActive(true);}
            else { vape.SetActive(false); }

        }
      
    }

    public void Yes()
    {
        SceneManager.LoadScene(sceneName: "MainScene");
    }
    public void No()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }


}
