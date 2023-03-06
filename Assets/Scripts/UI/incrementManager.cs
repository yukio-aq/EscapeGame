using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class incrementManager : MonoBehaviour
{
    [SerializeField] TMP_Text numberText;
    public int password = 0;

    public void OnClick()
    {
        password++;
        numberText.text = password.ToString();
    }
}
