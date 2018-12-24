//Create a new DropdownHandler GameObject by going to the Hierarchy and clicking Create>UI>DropdownHandler. Attach this script to the DropdownHandler GameObject.
//Set your own Text in the Inspector window

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public Dropdown m_Dropdown;
    private List<String> dropDownList;
    private Controller controller;
    private String elementSelected;

    public string ElementSelected
    {
        get
        {
            return elementSelected;
        }

        set
        {
            elementSelected = value;
        }
    }

    public ChemLogic ChemLogic
    {
        get
        {
            return controller.ChemLogic;
        }

        set
        {
            controller.ChemLogic = value;
        }
    }

    void Start()
    {
        
        PopulateDropDown();
        controller = GetComponent<Controller>();
        controller.ChemLogic = new ChemLogic(dropDownList[m_Dropdown.value]);

    }

    private void Update()
    {
       
    }

    private void PopulateDropDown()
    {
        dropDownList = new List<string> {"Wasser", "Kohlenstoffmonoxid", "Kohlenstoffdioxid" };
        m_Dropdown.AddOptions(dropDownList);
        m_Dropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(m_Dropdown);
        });
    }

    void DropdownValueChanged(Dropdown change)
    {
        controller.ChemLogic = new ChemLogic(dropDownList[change.value]);
    }
}