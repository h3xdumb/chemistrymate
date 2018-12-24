using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader : MonoBehaviour {
    private Dictionary<string, GameObject> modelList = new Dictionary<string, GameObject>();
    public GameObject h;
    public GameObject c;
    public GameObject o;

    public Dictionary<string, GameObject> ModelList
    {
        get
        {
            return modelList;
        }

        set
        {
            modelList = value;
        }
    }

    // Use this for initialization
    void Start () {
        ModelList.Add(Constants.H, h);
        ModelList.Add(Constants.C, c);
        ModelList.Add(Constants.O, o);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
