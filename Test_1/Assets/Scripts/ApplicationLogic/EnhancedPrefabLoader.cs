﻿using UnityEngine;
using Vuforia;
using System.Collections;
using System;

public class EnhancedPrefabLoader : MonoBehaviour, ITrackableEventHandler {
  private TrackableBehaviour mTrackableBehaviour;
  public Transform myModelPrefab;
  // Use this for initialization
  void Start ()
  {
    if (mTrackableBehaviour) {
      mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }
  }
  // Update is called once per frame
  void Update ()
  {
        
    }
  public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
  { 
    if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
    {
      OnTrackingFound();
    }
  } 
  private void OnTrackingFound()
  {
    if (myModelPrefab != null)
    {
            if (mTrackableBehaviour.TrackableName.Equals("2"))
            {
                Debug.Log("FOUND 2!");
            }

      Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
      myModelTrf.parent = mTrackableBehaviour.transform;
      myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
      myModelTrf.localRotation = Quaternion.identity;
      myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
      myModelTrf.gameObject.SetActive(true);
    }
  }
}