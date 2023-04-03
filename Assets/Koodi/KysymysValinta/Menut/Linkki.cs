using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autopeli
{
    public class Linkki : MonoBehaviour
    {
        public void OpenLink()
        {
            Application.OpenURL("https://www.finlex.fi/fi/laki/ajantasa/2001/20010055");
        }
    }
}
