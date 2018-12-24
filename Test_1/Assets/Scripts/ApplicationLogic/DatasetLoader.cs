using UnityEngine;
using System.Collections;
 
using Vuforia;
using System.Collections.Generic;
 
 
public class DatasetLoader : MonoBehaviour
{
    // specify these in Unity Inspector
    private Dictionary<string, GameObject> gameObjects; // you can use teapot or other object
    public string dataSetName;  //  Assets/StreamingAssets/QCAR/DataSetName

 
    // Use this for initialization
    void Start()
    {
        gameObjects = GetComponent<PrefabLoader>().ModelList;
        // Vuforia 6.2+
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(LoadDataSet);
    }
         
    void LoadDataSet()
    {
        gameObjects = GetComponent<PrefabLoader>().ModelList;
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
         
        DataSet dataSet = objectTracker.CreateDataSet();
         
        if (dataSet.Load(dataSetName)) {
             
            objectTracker.Stop();  // stop tracker so that we can add new dataset
 
            if (!objectTracker.ActivateDataSet(dataSet)) {
                // Note: ImageTracker cannot have more than 100 total targets activated
                Debug.Log("<color=yellow>Failed to Activate DataSet: " + dataSetName + "</color>");
            }
 
            if (!objectTracker.Start()) {
                Debug.Log("<color=yellow>Tracker Failed to Start.</color>");
            }
 
            int counter = 0;
 
            IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
            foreach (TrackableBehaviour tb in tbs) {

                GameObject augmentationObject;
                gameObjects.TryGetValue(tb.TrackableName, out augmentationObject);
                    
                    
                   
                    tb.gameObject.name = ++counter + ":DynamicImageTarget-" + tb.TrackableName;
 
                    // add additional script components for trackable
                    tb.gameObject.AddComponent<DefaultTrackableEventHandler>();
                    tb.gameObject.AddComponent<TurnOffBehaviour>();
 
                    if (augmentationObject != null) {
                        // instantiate augmentation object and parent to trackable
                        GameObject augmentation = (GameObject)GameObject.Instantiate(augmentationObject);
                        augmentation.transform.parent = tb.gameObject.transform;
                        augmentation.transform.localPosition = new Vector3(0f, 0f, 0f);
                        augmentation.transform.localRotation = Quaternion.identity;
                        augmentation.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        augmentation.gameObject.SetActive(true);
                    } else {
                        Debug.Log("<color=yellow>Warning: No augmentation object specified for: " + tb.TrackableName + "</color>");
                    }
                }
            }
        } 
    
}