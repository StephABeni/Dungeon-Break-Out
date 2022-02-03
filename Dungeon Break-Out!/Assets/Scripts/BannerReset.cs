using DuloGames.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class BannerReset : MonoBehaviour
    {
        public GameObject[] rings;
        public bool ringsOff;
        public UIItemInfo itemInfo;

        public void Awake()
        {
            itemInfo = gameObject.GetComponent<InteractableItem>().itemInfo;
        }

        public void Update()
        {
            if (itemInfo.Pushed)
            {
                foreach (GameObject ring in rings)
                {
                    ring.SetActive(false);
                }
            }
        }
    }
}
