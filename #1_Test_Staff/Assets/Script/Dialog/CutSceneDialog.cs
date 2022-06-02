using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutSceneDialog : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Transform DialogTransform;
    public GameObject CanvasDialog;
    private SecondCharacterScript secondCharacterScript;
    private Image image;
    public bool _CutScene;
    private void Awake()
    {
        secondCharacterScript = FindObjectOfType<SecondCharacterScript>();
        image = this.gameObject.GetComponent<Image>();
        _CutScene = false;
        CanvasDialog.SetActive(false);
    }
    private void Update()
    {
        if (secondCharacterScript.IsCol && !_CutScene)
        {
            var AlphaValue = image.color;
            AlphaValue.a = 1f;
            image.color = AlphaValue;
            StartCoroutine(TeleportDialog());
        }

    }
    IEnumerator TeleportDialog()
    {

        yield return new WaitForSeconds(1f);
        var AlphaValue = image.color;
        AlphaValue.a = 0f;
        image.color = AlphaValue;
        _CutScene = true;
        Player.transform.position = new Vector3(-7, 0, -2);
        Player.transform.eulerAngles = new Vector3(0, 20, 0);
        CanvasDialog.SetActive(true);
    }
}
