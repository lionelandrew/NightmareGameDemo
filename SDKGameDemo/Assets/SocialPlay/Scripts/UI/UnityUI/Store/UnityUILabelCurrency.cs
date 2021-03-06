﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class UnityUILabelCurrency : MonoBehaviour {

    public CurrencyType type = CurrencyType.Standard;
    Text mLabel;

    void Awake()
    {
        mLabel = GetComponent<Text>();
        if (type == CurrencyType.Standard) SP.OnStandardCurrency += OnFreeCurrency;
        else if (type == CurrencyType.Premium) SP.OnPremiumCurrency += OnPaidCurrency;
    }

    void OnFreeCurrency(int currency)
    {
        mLabel.text = currency.ToString();
    }

    void OnPaidCurrency(int currency)
    {
        mLabel.text = currency.ToString();
    }
}
