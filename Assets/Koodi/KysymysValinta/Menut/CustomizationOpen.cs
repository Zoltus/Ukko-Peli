using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class CustomizationOpen : MonoBehaviour
    {
        
        public GameObject customization;



        public void OpenCustomization()
        {
            customization.SetActive(true);
        }

        public void CloseCustomizatoin()
        {
            customization.SetActive(false);
        }

    }
}
