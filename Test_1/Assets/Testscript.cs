using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Testscript : MonoBehaviour {
    public GameObject connector;
    public GameObject rot, blau;
	// Use this for initialization
	void Start () {
        
       
       // go.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in tbs)
        {
            Debug.Log("TrackableName: xx" + tb.name);
        }
        rot = GameObject.Find("O/blau");
    
        Vector3 pos=rot.transform.position;
        Vector3 pos2 = GameObject.Find("H/rot").transform.position;
        Vector3 posfinal = new Vector3();
        posfinal.x = pos2.x;
        posfinal.y = pos.y;
        posfinal.z = pos.z;
        Debug.Log(pos2);
        GameObject gameObject1 = (GameObject)Instantiate(connector, posfinal, Quaternion.identity);
        GameObject go = gameObject1; 
    }
  
    void OnCollisionEnter(Collision otherObj)
    {
        
       
    }
}
