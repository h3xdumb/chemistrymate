using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_button;
    public Text m_text;
    private Controller controller;
    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        controller = GetComponent<Controller>();
        m_button.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        DropdownHandler drpHandler = GetComponent<DropdownHandler>();
        if (controller.ChemLogic.Validate("H2O"))
        {
            m_text.color = Color.green;
            m_text.text = "SUCCESS";
        }
        else
        {
           m_text.color = Color.red;
           m_text.text = "FAILURE";
        }
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
}