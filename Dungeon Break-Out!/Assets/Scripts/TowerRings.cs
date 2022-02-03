using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuloGames.UI;
using DuloGames.UI.Tweens;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TowerRings : MonoBehaviour
    {
        UIItemInfo itemInfo;
        GameObject ring;

        private void Awake()
        {
            itemInfo = gameObject.GetComponent<InteractableItem>().itemInfo;
            ring = gameObject.transform.GetChild(0).gameObject;
        }

        public void Update()
        {
            if ((itemInfo.Pushed && !ring.activeInHierarchy) ||
                (!itemInfo.Pushed && ring.activeInHierarchy))
            {
                ring.SetActive(gameObject.GetComponent<InteractableItem>().itemInfo.Pushed);
            }
        }
    }
}
