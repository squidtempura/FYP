using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public static int HealthCurrent;
    public static int HealthMax;
    private Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float) HealthCurrent / (float) HealthMax;
        healthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
