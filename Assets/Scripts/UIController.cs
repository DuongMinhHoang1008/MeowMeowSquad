using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject showCoinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showCoinText != null) {
            showCoinText.GetComponent<TextMeshProUGUI>().text = GlobalVar.Instance().coin.ToString();
        }
    }
}
