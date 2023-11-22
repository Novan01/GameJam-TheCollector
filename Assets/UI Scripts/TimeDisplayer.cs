using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplayer : MonoBehaviour
{
    [SerializeField] GameObject timeController;
    private LightingManager lm;

    private TextMeshProUGUI timeText;
    // Update is called once per frame.

    void Start(){
        timeText = GetComponent<TextMeshProUGUI>();
        lm = timeController.GetComponent<LightingManager>();
    }

    void Update()
    {
        if(Mathf.Round(lm.getTimeOfDay()) != 0.0f)
        {
            if (Mathf.Round(((((Mathf.Round(lm.getTimeOfDay() * 100)) / 100.0f) % 1) * 60)) > 9)
                timeText.text = (int)(((lm.getTimeOfDay() * 100)) / 100) + ":" + Mathf.Round(((((Mathf.Round(lm.getTimeOfDay() * 100)) / 100.0f) % 1) * 60));
            else
                timeText.text = (int)(((lm.getTimeOfDay() * 100)) / 100) + ":0" + Mathf.Round(((((Mathf.Round(lm.getTimeOfDay() * 100)) / 100.0f) % 1) * 60));
        }
        else
            timeText.text = "1:00";
    }
}
