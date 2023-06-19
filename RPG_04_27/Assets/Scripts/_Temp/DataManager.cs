using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField ageField;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Name"));
        Debug.Log(PlayerPrefs.GetInt("Age"));

        nameField.text = PlayerPrefs.GetString("Name");
        //ageField.text = PlayerPrefs.GetInt("Age").ToString();
        ageField.text = PlayerPrefs.GetInt("Age")  + "";
    }

    public void SaveData()
    {
        if (nameField.text != "" && ageField.text != "")
        {
            PlayerPrefs.SetString("Name", nameField.text);
            PlayerPrefs.SetInt("Age", int.Parse(ageField.text));
            Debug.Log("저장이 완료되었습니다.");
            PlayerPrefs.Save();
        }
    }
}
