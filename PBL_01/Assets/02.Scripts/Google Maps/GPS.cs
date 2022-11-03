using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GPS : MonoBehaviour
{
    public static float latitude;
    public static float longitude;

    private void Start()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif
        
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled location");
            yield break;
        }
        Input.location.Start();
        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(1);
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            while (true)
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                //Latitude.text = "위도: " + GoogleStaticMap.url;
                //Longtitude.text = "경도: "+longitude.ToString();
                Debug.Log("Latitude : " + Input.location.lastData.latitude);
                Debug.Log("Longitude : " + Input.location.lastData.longitude);
                Debug.Log("Altitude : " + Input.location.lastData.altitude);
                yield return new WaitForSeconds(1f);
            }
        }
    }

}
