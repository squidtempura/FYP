using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public int startCoinNum;
    public Text coinNum;
    public static int CurrentCoinNum;
    // Start is called before the first frame update
    void Start()
    {
        CurrentCoinNum = startCoinNum;
    }

    // Update is called once per frame
    void Update()
    {
        coinNum.text = CurrentCoinNum.ToString();
    }
}
