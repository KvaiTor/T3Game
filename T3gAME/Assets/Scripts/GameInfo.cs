using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Info
{
    public class GameInfo : MonoBehaviour
    {
        public Text pointsInfo;
        [SerializeField] public int points;
        void Start()
        {
            points = 0;
        }
        private void LateUpdate()
        {
            pointsInfo.text = points.ToString();
        }
    }
}
