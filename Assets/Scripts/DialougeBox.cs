using System.ComponentModel;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialougeBox : MonoBehaviour
{
    public GameObject canvas;
    public GameObject options;
    GameObject varGameObject;
    public TextMeshProUGUI convo;
    int x = 2;
    int y;
    bool colliding;
    bool isDone;
    bool isBad;
    string[] lines;
    public string con;
    public Goodendtrigger gEnd;
    
    void Start()
    {
        varGameObject = GameObject.Find("Main Camera");
        lines = System.IO.File.ReadAllLines(con);
        y = lines.Length;
    }
    void Update()
    {
        if (colliding && Input.GetMouseButtonDown(0))
        {
            textSystem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        options.SetActive(false);
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        colliding = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        varGameObject.GetComponent<CameraFollow>().enabled = true;
        if (isDone) { Destroy(gameObject); } 
        if (isBad) { SceneManager.LoadScene(sceneName: "BadEnd"); }
    }

    void textSystem()
    {
        if (x == y)
        {
            convo.text = "";
            options.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            varGameObject.GetComponent<CameraFollow>().enabled = false;
        }

        if (x < y)
        {
            convo.text = lines[x];
            x++;  
        }
 
    }

    public void Yes()
    {
        options.SetActive(false);
        convo.text = lines[0];
        colliding = false;
        isBad = true;
    }
    public void No()
    {
        options.SetActive(false);
        convo.text = lines[1];
        isDone = true;
        colliding = false;
        gEnd.goodPoints++;
    }


}
