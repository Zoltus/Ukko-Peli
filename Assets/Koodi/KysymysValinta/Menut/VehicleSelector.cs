using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Autopeli
{

    public enum VehicleType
    {
        Car1,
        Car2,
        Car3,
        Car4,
        Motorcycle
    }

    public class VehicleSelector : MonoBehaviour
    {
        public Sprite[] vehicleSprites;

        public VehicleType SelectedVehicle = VehicleType.Car1;

        public Image selectedCarImage;

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
            SelectedVehicle--;

            if (SelectedVehicle < 0)
            {
                SelectedVehicle = VehicleType.Motorcycle;
            }

            UpdateActiveVehicle();
        }

        void NextVehicle()
        {
            SelectedVehicle++;

            if (SelectedVehicle > VehicleType.Motorcycle)
            {
                SelectedVehicle = VehicleType.Car1;
            }

            UpdateActiveVehicle();
        }

        void UpdateActiveVehicle()
        {
            selectedCarImage.sprite = vehicleSprites[(int)SelectedVehicle];
        }
    }
}