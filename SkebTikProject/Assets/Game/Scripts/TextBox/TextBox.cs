using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TextBox : MonoBehaviour
{
    public GameObject TempTex;
    public Gate MyGate;
    public Gate MyCoupleGate;
    void Start()
    {
        MyGate = transform.GetComponentInParent<Gate>();
        TextSpawn();
        GameManager.GateTriggerAction+= TextSpawn;
    }
    private void OnDisable()
    {
        GameManager.GateTriggerAction-= TextSpawn;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void TextSpawn()
    {
        if (TempTex!=null)
        {
            Destroy(TempTex);
        }
        var textPoz = new Vector3(0, 0.5f, -1.7f);
        var player = GameManager.Instance.CurrentLevel.PlayerController;
        if (!MyGate.Trigged&&!MyCoupleGate.Trigged)
        {
            if (gameObject.tag == "Positive")
            {
                var newText = Instantiate(GameManager.Instance.CurrentLevel.DataTextState.Positive[player.GateIndex], textPoz, Quaternion.identity, transform);
                if (MyGate.Rotete)
                {
                    newText.transform.DOLocalRotate(new Vector3(0,180,180), 0.001f);
                    newText.transform.localPosition = new Vector3(0, 0.5f, 1.6f);
                }
                else
                {
                    newText.transform.DOLocalRotate(new Vector3(0, 0, -180), 0.001f);
                    //newText.transform.DOLocalRotate(textPoz, 0.001f);
                    newText.transform.localPosition = textPoz;
                }
                TempTex = newText;
            }
            else
            {
                var newText = Instantiate(GameManager.Instance.CurrentLevel.DataTextState.Negative[player.GateIndex], textPoz, Quaternion.identity, transform);
                if (MyGate.Rotete)
                {
                    newText.transform.DOLocalRotate(new Vector3(0, 180, 180), 0.001f);
                    newText.transform.localPosition = new Vector3(0, 0.5f, 1.6f);
                }
                else
                {
                    newText.transform.DOLocalRotate(new Vector3(0,0,-180), 0.001f);
                    //newText.transform.DOLocalRotate(textPoz, 0.001f);
                    newText.transform.localPosition = textPoz;
                }
                TempTex = newText;
            }
        }
        
    }
}
