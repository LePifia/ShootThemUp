using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameSet : MonoBehaviour
{

    public static NameSet Instance { get; private set; }
    private string NameDisplay;
    private string NameSetted;
    [SerializeField] GameObject inputField;


    // Start is called before the first frame update

    private void Awake()
    {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            
        
        NameSetted = PlayerPrefs.GetString("NameRank");
    }
    public void NameSetter()
    {

        NameDisplay = inputField.GetComponent<TextMeshProUGUI>().text;

        PlayerPrefs.SetString("NameRank", NameDisplay);
    }

    public string Name()
    {
        return NameSetted;
    }
}
