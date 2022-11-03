using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoogleStaticMap : MonoBehaviour
{
	//public Button start, finish;
	public static string url;
	public RawImage rawImage;
	[Range(0f, 1f)]
	public float transparency = 1f;
	string path;
	int i = 0;
	float[] pLatitude = new float[100];
	float[] pLongtitude = new float[100];
	[Range(1, 20)]
	public int mapZoom =16;
	public int mapWidth = 1080;
	public int mapHeight =1080;

	float mapCenterLatitude;
	float mapCenterLongtitude;
	float markerLatitude;
	float markerLongtitude;

	public enum MapType
	{
		roadmap, satellite, terrain, hybrid,
	}
	public MapType mapType = MapType.roadmap;
	[Range(1, 4)]
	public int scale = 1;

	public enum MarkerSize
	{
		tiny, mid, small,
	}
	public MarkerSize markerSize = MarkerSize.mid;
	public enum MarkerColor
	{
		black, brown, green, purple, yellow, blue, gray, orange, red, white,
	}
	public MarkerColor markerColor = MarkerColor.blue;
	public char label = 'C';
	public string apiKey;

	//private string url;
	private Color rawImageColor = Color.white;

	IEnumerator Map()
	{ 

		pLatitude[i] = GPS.latitude;
		pLongtitude[i] = GPS.longitude;


        if (i < 1)
        {
			path += "%7C" + pLatitude[i] + "," + pLongtitude[i];
			i++;
		}
        else
        {
			if (pLatitude[i] != GPS.latitude || pLongtitude[i - 1] != GPS.longitude)
			{
				path += "%7C" + pLatitude[i] + "," + pLongtitude[i];
				i++;
			}
		}
		markerLatitude = GPS.latitude;
		markerLongtitude = GPS.longitude;

		mapCenterLatitude = markerLatitude;
		mapCenterLongtitude = markerLongtitude;

		rawImageColor.a = transparency;
		rawImage.color = rawImageColor;

		label = Char.ToUpper(label);
		
		url = "https://maps.googleapis.com/maps/api/staticmap"
			+ "?center=" + mapCenterLatitude + "," + mapCenterLongtitude
			+ "&zoom=" + mapZoom
			+ "&size=" + mapWidth + "x" + mapHeight
			+ "&scale=" + scale
			+ "&maptype=" + mapType
			+ "&markers=size:" + markerSize + "%7Ccolor:" + markerColor + "%7Clabel:" + label + "%7C" + markerLatitude + "," + markerLongtitude
			+ "&path=weight:5%7Ccolor:orange" + path
			+ "&key=" + apiKey;

		//Debug.Log(url);
		WWW www = new WWW(url);
		yield return www;
		rawImage.texture = www.texture;
		rawImage.SetNativeSize();
	}

	public void RefreshMap()
	{
		if (gameObject.activeInHierarchy)
		{
			StartCoroutine(Map());
		}
	}

	private void Reset()
	{
		rawImage = gameObject.GetComponentInChildren<RawImage>();
		InvokeRepeating("RefreshMap", 1f, 5f);
		//RefreshMap();

	}

	private void Start()
	{
	
	}

    private void Update()
    {
		//markerLatitude = GPS.latitude;
		//markerLongtitude = GPS.longitude;
	}

	public void startWalk()
    {
		Invoke("Reset", 1f);
	}
	public void finishWalk()
	{
		CancelInvoke("RefreshMap");
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		RefreshMap();
	}
#endif
}
