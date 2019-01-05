using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour trackableBehaviour;
    private TrackableBehaviour.Status m_PreviousStatus;
    private TrackableBehaviour.Status m_NewStatus;

    public CustomTrackableEventHandler(TrackableBehaviour trackableBehaviour)
    {
        this.trackableBehaviour = trackableBehaviour;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

           /*
            * trackable found
            */ 
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            /*
             * trackable lost
             */ 
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    private void OnTrackingLost()
    {
        
    }

    private void OnTrackingFound()
    {

        DynamicLoader dynamicLoader = FindObjectOfType<DynamicLoader>();
        int n = 0;
        bool isNumeric = Int32.TryParse(trackableBehaviour.TrackableName, out n);

        if (isNumeric)
        {
            dynamicLoader.getMolekule(n);
        }
    }



    // Use this for initialization
    void Start () {
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        foreach (Vuforia.ImageTargetBehaviour tb in tbs)
        {
            if (tb)
            {
                tb.RegisterTrackableEventHandler(new CustomTrackableEventHandler(tb));
            }

        }
        
	}

    void OnDestroy()
    {
        if (trackableBehaviour)
        {
            trackableBehaviour.UnregisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
