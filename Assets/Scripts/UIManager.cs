using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private IAPListener iapListener;
    
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void Log(string message)
    {
        textMeshProUGUI.text = message;
    }

    public void OnPurchaseComplete(Product product)
    {
        textMeshProUGUI.text = product.receipt;
    }

    public void OnProductsFetched(ProductCollection products)
    {
        var str = "";
        foreach (var product in products.all)
        {
            str += product.receipt + "\n";
        }

        textMeshProUGUI.text = str;
    }
    
    public void CheckSubscription()
    {
        
    }
}
