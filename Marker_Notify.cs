using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Assets.Scripts
{
    public class Marker_Notify : MonoBehaviour,INotificationReceiver
    {

        PlayableDirector pd;
        private void Awake()
        {
            pd = GetComponent<PlayableDirector>();
        }
        // Use this for initialization
        void Start()
        {
            
        }
        void pause()
        {
            pd.timeUpdateMode = DirectorUpdateMode.GameTime;
            pd.Play();
            pd.Pause();
        }
        public void OnNotify(Playable origin, INotification notification, object context)
        {
            if (notification != null)
            {
                double time = origin.IsValid() ? origin.GetTime() : 0.0;
                
                Marker_pause tmp = notification as Marker_pause;
                Debug.LogFormat( $"Received notification of time:{tmp.time} at real time {time}" );

                double t = pd.time; // Store elapsed time
                //pd.RebuildGraph(); // Rebuild graph
                pd.time = t+1; // Restore elapsed time
                pd.Evaluate();
                pd.Pause();
            }
        }

    }
}