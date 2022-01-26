using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PhonePanel : MonoBehaviour
{
    public TextMeshProUGUI LikeCountText;
    public TextMeshProUGUI CommentCountText;
    public TextMeshProUGUI ShareCounText;
    public GameObject LikeParticle;
    public Image LikeImage;
    public Image CommentImage;
    public Image ShareImage;
    public List<GameObject> Questions = new List<GameObject>();

    private double LikeCount;
    private double CommentCount;
    private double ShareCount;

    void Start()
    {
        CountAssigment();
        ImagesScaleYoyo();
    }

    private void OnDisable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CountAssigment()
    {
        LikeCount = Random.Range(50.1f,100.9f);
        DOTween.To(() => LikeCount, x => LikeCount = x, System.Math.Round(100.9f,1), 10f).OnUpdate(() => WriteValue(LikeCount, LikeCountText)).OnComplete(()=>LikeParticle.SetActive(false));
        CommentCount = Random.Range(1000f, 9000f);
        DOTween.To(() => CommentCount, x => CommentCount = x, System.Math.Round(9000f,0), 10f).OnUpdate(() => CommentWrite(CommentCount,CommentCountText));
        ShareCount = Random.Range(25.1f, 60.9f);
        DOTween.To(() => ShareCount, x => ShareCount = x, System.Math.Round(60.9f, 1), 10f).OnUpdate(() => WriteValue(ShareCount, ShareCounText));
        CommentCountText.text = CommentCount.ToString();

    }

    private void WriteValue(double _count,TextMeshProUGUI _text)
    {
        _count = System.Math.Round(_count, 1);
        _text.text = _count.ToString() + "K";
    }

    private void CommentWrite(double _count, TextMeshProUGUI _text)
    {
        _count = System.Math.Round(_count, 0);
        _text.text = _count.ToString();

    }
    private void ImagesScaleYoyo()
    {
        LikeImage.transform.DOScale(0.6f, 0.3f).SetLoops(-1, LoopType.Yoyo);
        CommentImage.transform.DOScale(0.6f, 0.3f).SetLoops(-1, LoopType.Yoyo);
        ShareImage.transform.DOScale(0.6f, 0.3f).SetLoops(-1, LoopType.Yoyo);

    }

    
}
