using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{
    public class VehicleSelector : MonoBehaviour
    {
        public Sprite[] vehicleSprites;

        public Image selectedCarImage;

        private int selectedVehicleIndex = 0;

        void Start()
        {
            UpdateActiveVehicle();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PreviousVehicle();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextVehicle();
            }
        }

        void PreviousVehicle()
        {
            selectedVehicleIndex--;

            if (selectedVehicleIndex < 0)
            {
                selectedVehicleIndex = vehicleSprites.Length - 1;
            }

            UpdateActiveVehicle();
        }

        void NextVehicle()
        {
            selectedVehicleIndex++;

            if (selectedVehicleIndex >= vehicleSprites.Length)
            {
                selectedVehicleIndex = 0;
            }

            UpdateActiveVehicle();
        }

        void UpdateActiveVehicle()
        {
            selectedCarImage.sprite = vehicleSprites[selectedVehicleIndex];
        }

        public void SetSelectedVehicleByIndex(int index)
        {
            selectedVehicleIndex = Mathf.Clamp(index, 0, vehicleSprites.Length - 1);
            UpdateActiveVehicle();
        }
    }
}