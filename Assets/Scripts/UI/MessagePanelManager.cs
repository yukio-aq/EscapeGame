using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MessagePanelManager : MonoBehaviour
{
    public static MessagePanelManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject messagePanel = default;
    [SerializeField] TextMeshProUGUI messageText = default;

    public void Start()
    {
        messagePanel.SetActive(false);
    }

    public void ShowPanel(string message)
    {
        messageText.text = message;
        StartCoroutine("ChangeState");
    }

    public IEnumerator ChangeState()
    {
        messagePanel.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        messagePanel.SetActive(false);
    }
}
