using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border
{
    location startPoint { get; set; }
    location endPoint { get; set; }
    int upperArea { get; set; }
    int lowerArea { get; set; }

    public void border(location startPoint, location endPoint, int upperArea, int lowerArea)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.upperArea = upperArea;
        this.lowerArea = lowerArea;
    }
}
