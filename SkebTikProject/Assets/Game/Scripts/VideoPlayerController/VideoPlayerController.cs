using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public bool ActionBool = false;
    public Male Male;
    public Female Female;
    public Camera Camera;
    public List<HumanState> VideoHumanState = new List<HumanState>();
    void Start()
    {
        Finish.FinishAction += FinishStatus;
    }

    private void OnDisable()
    {
        Finish.FinishAction -= FinishStatus;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionBool)
        {
            transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }
    }

    private void VideoControlCenter()
    {
        StartCoroutine(ControlTime());
    }

    private IEnumerator ControlTime()
    {
        yield return new WaitForSeconds(2f);
        Camera.gameObject.SetActive(true);
        Male.GetComponent<Animator>().CrossFade("Walk", 0.01f);
        Female.GetComponent<Animator>().CrossFade("Walk", 0.01f);
        yield return new WaitForSeconds(2f);
        Male.HumanState = VideoHumanState[0];
        Female.HumanState = VideoHumanState[0];
        yield return new WaitForSeconds(2f);
        Male.HumanState = VideoHumanState[1];
        Female.HumanState = VideoHumanState[1];
        yield return new WaitForSeconds(2f);
        Male.HumanState = VideoHumanState[2];
        Female.HumanState = VideoHumanState[2];
        yield return new WaitForSeconds(2f);
        Male.IdleStatus();
        Female.IdleStatus();
        ActionBool = false;
        Camera.GetComponent<SecondKamera>().enabled = false;

    }

    private void FinishStatus()
    {
        GameManager.Instance.CurrentLevel.PlayerController.enabled = false;
        Male.gameObject.SetActive(true);
        Female.gameObject.SetActive(true);
        ActionBool = true;
        VideoControlCenter();
    }
}
