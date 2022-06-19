using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationKey : MonoBehaviour
{
    [SerializeField] private string _key;
    private Text _keyText;

    public string GetKey() { return _key; }
    public void SetKeyText(string keyText) { _keyText.text = keyText; }

    private void Awake()
    {
        _keyText = GetComponent<Text>();
    }
}