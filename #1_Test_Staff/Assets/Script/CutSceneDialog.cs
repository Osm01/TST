using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutSceneDialog : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Transform DialogTransform;
    private SecondCharacterScript secondCharacterScript;
    private Image image;
    public bool _CutScene;
    private void Awake()
    {
        secondCharacterScript = FindObjectOfType<SecondCharacterScript>();
        image = this.gameObject.GetComponent<Image>();
        _CutScene = false;
    }
    private void Update()
    {
        if (secondCharacterScript.IsCol && !_CutScene)
        {
            var AlphaValue = image.color;
            AlphaValue.a = 1f;
            image.color = AlphaValue;
            Invoke("CharacterCutScneDialog", 1f);
        }
       
    }
    void CharacterCutScneDialog()
    {
        var AlphaValue = image.color;
        AlphaValue.a = 0f;
        image.color = AlphaValue;
        _CutScene = true;
        Player.transform.localPosition = DialogTransform.localPosition;
        Player.transform.eulerAngles = DialogTransform.eulerAngles;
    }
}
