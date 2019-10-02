using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject destination;
    public GameObject demoObject;
    public Text startGame;
    private Color color;


    void Start()
    {
        startGame = gameObject.GetComponentInChildren<Text>();
        color = new Color(startGame.color.r, startGame.color.g, startGame.color.b);
        StartCoroutine(StartAnim());
       
    }

    void Update()
    {
        color.a = Mathf.PingPong(Time.time * 1, 1f);
        startGame.color = color;
        StartNewgame();

    }

    private IEnumerator StartAnim()
    {
        while (demoObject.transform.position.y < destination.transform.position.y)
        {
            demoObject.transform.position = Vector3.MoveTowards(demoObject.transform.position, destination.transform.position, 10f * Time.deltaTime);
            yield return null;
        }

    }

    private void StartNewgame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainScene");
        }
  
    }
}
