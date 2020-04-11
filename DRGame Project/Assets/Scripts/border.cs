using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border
{
    location startPoint { get; set; }
    location endPoint { get; set; }
    area upperArea { get; set; }
    area lowerArea { get; set; }

    public border(location startPoint, location endPoint, area upperArea, area lowerArea)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.upperArea = upperArea;
        this.lowerArea = lowerArea;
    }
}
