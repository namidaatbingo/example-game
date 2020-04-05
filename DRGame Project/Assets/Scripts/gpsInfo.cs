using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gpsInfo : MonoBehaviour
{

    //    public static AccurateGPS instance { get; private set; } // As a Singleton
    public List<float> lastKnownCoordinatesX; // Latitude
    public List<float> lastKnownCoordinatesY; // Longitude
    public Text dbgTxt; // Text to debug position

    private void Awake()
    {
        /*
                if (instance == null)
                {
                    instance = this;
                }
                if (instance != this)
                {
                    Destroy(gameObject);
                }
        */
        InvokeRepeating("ShowAcuratePos", 3, 1); // Show debug text
        InvokeRepeating("GetCurrentPos", 1, 1); // Get position each seconds
    }

    IEnumerator Start()
    {
        // The code in start function come from Unity3d official documentation
        // I just modified it a little
 /*       if (!AppManager.instance.CheckInternetConnection())
        {
            print("No internet connection");
            yield break;
        }
*/
        if (!Input.location.isEnabledByUser)
        {
            print("You need to activate geolocation");
            yield break;
        }

        Input.location.Start(.1f, .1f); // Start location service with 0.1m accuracy
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
    }

    public float GetAverageX() // Calculate average latitude
    {
        float totalX = 0;
        int cpt = 0;
        foreach (float x in lastKnownCoordinatesX)
        {
            totalX += x;
            cpt++;
        }
        return totalX / cpt;
    }

    public float GetAverageY() // Calculate average longitude
    {
        float totalY = 0;
        int cpt = 0;
        foreach (float y in lastKnownCoordinatesY)
        {
            totalY += y;
            cpt++;
        }
        return totalY / cpt;
    }

    void ShowAcuratePos() // Show accurate position in debug ui text and save pos to playerprefs
    {
        dbgTxt.text = "AcuratePos = " + GetAverageY() + "," + GetAverageX();
        PlayerPrefs.SetFloat("longitude", GetAverageY());
        PlayerPrefs.SetFloat("latitude", GetAverageX());
    }

    void GetCurrentPos() // Get position and add to lists
    {
        // Latitude
        if (lastKnownCoordinatesX.Count < 10)
        {
            lastKnownCoordinatesX.Add(Input.location.lastData.latitude);
        }
        else // If list contains 10 items
        {
            lastKnownCoordinatesX.RemoveAt(0);
            lastKnownCoordinatesX.Add(Input.location.lastData.latitude);
        }
        // Longitude
        if (lastKnownCoordinatesY.Count < 10)
        {
            lastKnownCoordinatesY.Add(Input.location.lastData.longitude);
        }
        else
        {
            lastKnownCoordinatesY.RemoveAt(0);
            lastKnownCoordinatesY.Add(Input.location.lastData.longitude);
        }
    }

    public void OpenMapsAtAccurateCoord() // I added a button to ui text to open google maps to test and see the result and it's pretty good
    {
        Application.OpenURL("https://www.google.fr/maps/dir//'" + GetAverageX() + "," + GetAverageY() + "'");

    }
}
