using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizationKey : MonoBehaviour
{
    [SerializeField] private string _key;
    private TMP_Text _keyText;

    public string GetKey() { return _key; }
    public void SetKeyText(string keyText) { _keyText.text = keyText; _keyText.text = _keyText.text.Replace("$$", "\n"); }

    private void Awake()
    {
        _keyText = GetComponent<TMP_Text>();
    }
}