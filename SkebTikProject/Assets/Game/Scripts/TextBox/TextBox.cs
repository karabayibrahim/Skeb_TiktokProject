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
        var textPoz = new Vector3(0, 0, 0);
        var player = GameManager.Instance.CurrentLevel.PlayerController;
        if (!MyGate.Trigged&&!MyCoupleGate.Trigged)
        {
            if (gameObject.tag == "Positive")
            {
                var newText = Instantiate(GameManager.Instance.CurrentLevel.DataTextState.Positive[player.GateIndex], textPoz, Quaternion.identity, transform);
                newText.transform.localPosition = textPoz;
                if (MyGate.Rotete)
                {
                    newText.transform.DOLocalRotate(new Vector3(0,180,0), 0.001f);
                }
                else
                {
                    newText.transform.DOLocalRotate(textPoz, 0.001f);
                }
                TempTex = newText;
            }
            else
            {
                var newText = Instantiate(GameManager.Instance.CurrentLevel.DataTextState.Negative[player.GateIndex], textPoz, Quaternion.identity, transform);
                newText.transform.localPosition = textPoz;
                if (MyGate.Rotete)
                {
                    newText.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.001f);
                }
                else
                {
                    newText.transform.DOLocalRotate(textPoz, 0.001f);
                }
                TempTex = newText;
            }
        }
        
    }
}
