using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemLogic {

    private string pattern;

    public ChemLogic(string molecule)
    {
        switch (molecule)
        {
            case Constants.WATER:
                this.pattern = Constants.WATER_MOLECULE;
                break;

            case Constants.CARBON_DIOXIDE:
                this.pattern = Constants.CARBON_DIOXIDE_MOLECULE;
                break;

            case Constants.CARBON_MONOXIDE:
                this.pattern = Constants.CARBON_MONOXIDE_MOLECULE;
                break;
        }
    }

    /*
     * 
     * 
     * Each image_target should be mapped to a single letter.
     * 
     * 
     */
    public bool Validate(string validateMe)
    {
        if (validateMe.Equals(this.pattern))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}


