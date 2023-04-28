using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class SpriteSelector : MonoBehaviour
    {
        public Sprite[] vehicleSprites; // An array of sprites representing the different vehicles.

        

       // VehicleSelector vehicleSelector = FindObjectOfType<VehicleSelector>();

        void Start()
        {
            
            int selectedVehicleIndex = PlayerPrefs.GetInt("SelectedVehicleIndex", 0); // Retrieve the selected vehicle index from PlayerPrefs.

            //vehicleSelector.SetSelectedVehicleByIndex(selectedVehicleIndex);


            Sprite selectedVehicleSprite = vehicleSprites[selectedVehicleIndex]; // Get the sprite for the selected vehicle index.

            GetComponent<SpriteRenderer>().sprite = selectedVehicleSprite; // Set the sprite renderer's sprite to the selected vehicle sprite.
        }

        

        

    }
}
