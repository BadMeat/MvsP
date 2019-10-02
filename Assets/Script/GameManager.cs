using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public int scoreMahasiswa { set; get; }
    public int scorePolice { set; get; }
    public Text txtMahasiswa;
    public Text txtPolice;

    public float healthMahasiswa { set; get; } = 100f;
    public float healthPolice { set; get; } = 100f;
    public float healthMahasiswaMax;
    public float healthPoliceMax;
    public Image imgMahasiswa;
    public Image imgPolice;

    private float healthMahasiswaCurrent;
    private float healthPoliceCurrent;

    public GameObject lockScreen;
    public Text textStart;

    public GameObject allButton;

    private AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    void Start()
    {
        src = GetComponent<AudioSource>();

        healthMahasiswaMax = healthMahasiswa;
        healthPoliceMax = healthPolice;
        RestartState();
    }

    void Update()
    {
        txtMahasiswa.text = scoreMahasiswa.ToString();
        txtPolice.text = scorePolice.ToString();
        healthMahasiswaCurrent = healthMahasiswa / healthMahasiswaMax;
        healthPoliceCurrent = healthPolice / healthPoliceMax;
        imgMahasiswa.transform.localScale = new Vector3(healthMahasiswaCurrent, 1, 1);
        imgPolice.transform.localScale = new Vector3(healthPoliceCurrent, 1, 1);
    }

    private IEnumerator NewGame()
    {
        src.PlayOneShot(clip);
        int counter = 5;
        while (counter > 0)
        {
            textStart.text = counter.ToString();
            yield return new WaitForSeconds(1);
            counter--;
        }
        textStart.text = "FIGHT !!!";
        yield return new WaitForSeconds(1);
        lockScreen.gameObject.SetActive(false);
    }

    public void SetWinScreen(int winState)
    {
        lockScreen.gameObject.SetActive(true);
        allButton.SetActive(true);
        if (winState == 1)
        {
            textStart.text = "Mahasiswa Win !!!";
        }
        else
        {
            
            textStart.text = "Police Win !!!";
        }
    }

    public void RestartState()
    {

        allButton.SetActive(false);

        healthMahasiswaCurrent = healthMahasiswaMax;
        healthMahasiswa = healthMahasiswaMax;

        healthPoliceCurrent = healthPoliceMax;
        healthPolice = healthPoliceMax;

        scoreMahasiswa = 0;
        scorePolice = 0;

        StartCoroutine(NewGame());
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
