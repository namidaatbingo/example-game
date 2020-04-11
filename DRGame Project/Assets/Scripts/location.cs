using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location
{
    double latitude { get; set; }
    double longitude { get; set; }

    public location(double latitude, double longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }
}
