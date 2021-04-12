using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_YourSecondButton, m_YourThirdButton;
    public TextMeshProUGUI m_Title;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
        m_YourFirstButton.onClick.AddListener(() => LoadScene(1));
        m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
        m_YourSecondButton.onClick.AddListener(() => LoadScene(2));
        m_YourThirdButton.onClick.AddListener(() => ButtonClicked(42));
        m_YourThirdButton.onClick.AddListener(TaskOnClick);
        m_Title.text = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            m_YourFirstButton.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            m_YourThirdButton.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "DeckScene")
        {
            m_YourSecondButton.gameObject.SetActive(false);
        }
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);
    }

    void LoadScene (int sce)
    {
        SceneManager.LoadScene(sce);  
    }
}
