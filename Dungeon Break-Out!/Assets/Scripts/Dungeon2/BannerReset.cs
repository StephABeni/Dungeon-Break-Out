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
        public Animator openDoor;
        public AudioSource doorCreak;

        public List<GameObject> candleBanners;
        public List<GameObject> gemBanners;
        public bool ringsOff;
        public UIItemInfo itemInfo;
        public bool puzzleComplete;

        public void Awake()
        {
            itemInfo = gameObject.GetComponent<InteractableItem>().itemInfo;
        }

        public void Update()
        {
            if (itemInfo.Pushed)
            {
                candleBanners.ForEach(x => x.GetComponent<InteractableItem>().itemInfo.Pushed = false);
                gemBanners.ForEach(x => x.GetComponent<InteractableItem>().itemInfo.Pushed = false);
                //foreach (GameObject banner in banners)
                //{
                //    banner.GetComponent<InteractableItem>().itemInfo.Pushed = false;
                //}
            }

            if (!puzzleComplete)
            {
                if (candleBanners.Where(x => x.GetComponent<InteractableItem>().itemInfo.Pushed == true).Count() == 2
                    && gemBanners.Where(x => x.GetComponent<InteractableItem>().itemInfo.Pushed == true).Count() == 3)
                {
                    openDoor.SetTrigger("unlockdoor");
                    PlayDoorCreak();
                }
            }
            itemInfo.Pushed = false;
        }

        private void PlayDoorCreak()
        {
            puzzleComplete = true;
            doorCreak.Play();
        }
    }
}
