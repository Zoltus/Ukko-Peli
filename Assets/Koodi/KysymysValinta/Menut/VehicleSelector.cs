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
        public GameObject Car1;
        public GameObject Car2;
        public GameObject Car3;
        public GameObject Car4;
        public GameObject Motorcycle;

        public VehicleType SelectedVehicle = VehicleType.Car1;

        public Image selectedCarImage;
     

        void Start()
        {
            selectedCarImage.sprite = Car1.GetComponent<SpriteRenderer>().sprite;
            
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
            Car1.SetActive(SelectedVehicle == VehicleType.Car1);
            Car2.SetActive(SelectedVehicle == VehicleType.Car2);
            Car3.SetActive(SelectedVehicle == VehicleType.Car3);
            Car4.SetActive(SelectedVehicle == VehicleType.Car4);
            Motorcycle.SetActive(SelectedVehicle == VehicleType.Motorcycle);

            switch (SelectedVehicle)
            {
                case VehicleType.Car1:
                    selectedCarImage.sprite = Car1.GetComponent<SpriteRenderer>().sprite;
                    break;
                case VehicleType.Car2:
                    selectedCarImage.sprite = Car2.GetComponent<SpriteRenderer>().sprite;
                    break;
                case VehicleType.Car3:
                    selectedCarImage.sprite = Car3.GetComponent<SpriteRenderer>().sprite;
                    break;
                case VehicleType.Car4:
                    selectedCarImage.sprite = Car4.GetComponent<SpriteRenderer>().sprite;
                    break;
                case VehicleType.Motorcycle:
                    selectedCarImage.sprite = Motorcycle.GetComponent<SpriteRenderer>().sprite;
                    break;
                default:
                    break;
            }
        }
    }
}
