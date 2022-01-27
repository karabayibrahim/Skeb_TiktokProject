using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject PhonePanel;
    public Image BarMove;
    public GameObject Bar;

    [Header ("StartPanel")]
    public GameObject GameStartPanel;
    public Button StartButton;
    [Header("InGamePanel")]
    public GameObject GameInPanel;
    public TextMeshProUGUI LevelText;
    public Button RetryButton;
    [Header("GameEndPanel")]
    public GameObject GameEndPanel;
    public Button NextButton;


    private float distance;
    private float startAmount;
    private float amount;
    private bool finishBool = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameAllEndAction += GameEndStatus;
        StartButton.onClick.AddListener(GameStartStatus);
        RetryButton.onClick.AddListener(Retry);
        NextButton.onClick.AddListener(NextButtonStatus);
        startAmount = Vector3.Distance(GameManager.Instance.CurrentLevel.FinishObject.gameObject.transform.position, GameManager.Instance.CurrentLevel.PlayerController.transform.position);
        Finish.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        Finish.FinishAction -= FinishStatus;
        GameManager.GameAllEndAction -= GameEndStatus;
        StartButton.onClick.RemoveListener(GameStartStatus);
        RetryButton.onClick.RemoveListener(Retry);
        NextButton.onClick.RemoveListener(NextButtonStatus);
    }
    // Update is called once per frame
    void Update()
    {
        BarMoveMove();
    }

    private void BarMoveMove()
    {
        if (!finishBool)
        {
            distance = Vector3.Distance(GameManager.Instance.CurrentLevel.FinishObject.gameObject.transform.position, GameManager.Instance.CurrentLevel.PlayerController.transform.position);
            amount = startAmount - distance;
            BarMove.fillAmount = amount / startAmount;
        }
    }

    private void FinishStatus()
    {
        StartCoroutine(PhonePanelTimer());
        Bar.SetActive(false);
        finishBool = true;
        BarMove.fillAmount = 1f;
        GameInPanel.SetActive(false);
    }

    private IEnumerator PhonePanelTimer()
    {
        yield return new WaitForSeconds(2f);
        PhonePanel.SetActive(true);
    }

    private void Retry()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextButtonStatus()
    {
        //GameManager.Instance.LevelIndex++;
        PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex")+1);
        if (PlayerPrefs.GetInt("LevelIndex") > 4)
        {
            SceneManager.LoadScene("Level" + Random.Range(2, 4));
        }
        else
        {

            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("LevelIndex"));
        }
        //if (GameManager.Instance.LevelIndex>3)
        //{
        //    GameManager.Instance.LevelIndex = Random.Range(0,3);
        //}
        //SceneManager.LoadScene(GameManager.Instance.LevelIndex);
    }

    private void GameStartStatus()
    {
        GameManager.Instance.GameStartStatus();
        GameStartPanel.SetActive(false);
        GameInPanel.SetActive(true);
        int levelIndex = PlayerPrefs.GetInt("LevelIndex");/*GameManager.Instance.LevelIndex + 1*/;
        LevelText.text = "LEVEL" + " " + levelIndex.ToString();
    }

    private void GameEndStatus()
    {
        GameEndPanel.SetActive(true);
    }
}
