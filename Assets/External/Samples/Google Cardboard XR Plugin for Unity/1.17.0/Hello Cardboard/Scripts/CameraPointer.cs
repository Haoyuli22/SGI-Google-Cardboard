//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    //private const float _maxDistance = 40;
    public bool navigate_mode = false;
    private  float _maxDistance = 40f;
    private GameObject _gazedAtObject = null;

    public GameObject ObjectGazed = null;
    public Vector3 hitpoint = new Vector3(0, 0, 0);

    private void Start()
    {
        if (navigate_mode) {
            _maxDistance = float.MaxValue;
        }
    }
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        if (navigate_mode)
        {
            _maxDistance = float.MaxValue;
        }
        ObjectGazed = _gazedAtObject;

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            hitpoint = hit.point;
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                //_gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                //_gazedAtObject.SendMessage("OnPointerEnter");


            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            //_gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            //_gazedAtObject?.SendMessage("OnPointerClick");
        }
    }

    public GameObject getGazed()
    {
        return _gazedAtObject;
    }
}