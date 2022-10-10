using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Marker_pause : Marker, INotification
{
    public PropertyName id { get; }
    public string desc;
    public string stepKey;
}
