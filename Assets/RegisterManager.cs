﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ApiData;

public class RegisterManager : PageLogic
{
    public Button registerButton;
    public InputField[] listOfInputs;

    public void Start()
    {
        registerButton.onClick.AddListener(RegisterButtonClicked);
    }

    public void RegisterButtonClicked()
    {
        HideRegisterButton();
        Dictionary<string, string> inputNameWithValue = new Dictionary<string, string>();

        foreach(InputField input in listOfInputs)
        {
            if (input.text == "" || input.text.Length == 0)
            {
                PopupManager.PopupAlert("Empty input", "The input " + input.placeholder + " is empty, please fill it");
                return;
            }

            inputNameWithValue.Add(input.placeholder.GetComponent<Text>().text, input.text);
        }

        ApiToken apiToken = GameManager.Instance.apiManager.RegisterToApi(
            inputNameWithValue["Pseudo"], 
            inputNameWithValue["Firstname"], 
            inputNameWithValue["Lastname"],
            inputNameWithValue["Email"],
            inputNameWithValue["Password"]);

        if (apiToken == null)
        {
            Debug.LogError("[WARNING]: apiToken is null");
            PopupManager.PopupAlert("Error", ApiManager.lastHttpWebRequestErrorMessage);
            ShowRegisterButton();
            return;
        }

        GameManager.Instance.apiManager.apiTokenManager.SetApiToken(apiToken);
        PopupManager.PopupAlert("Registered", "Successfully registered!", "Go", GameManager.Instance.pagesManager.ShowMenuPage);
    }



    void ShowRegisterButton()
    {
        registerButton.gameObject.SetActive(true);
    }

    void HideRegisterButton()
    {
        registerButton.gameObject.SetActive(false);
    }
}