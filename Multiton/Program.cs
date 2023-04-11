using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("marka");// Aynı
            Camera camera2 = Camera.GetCamera("marka2");// Farklı
            Camera camera1re = Camera.GetCamera("marka"); // Aynı

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera1re.Id);

            Console.ReadLine();
        }
    }

    class Camera
    {
        static Dictionary<string,Camera> _cameras = new Dictionary<string,Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }
        private string brand;

        private Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if(!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
                return _cameras[brand];
            }
            
        }

    }

}
