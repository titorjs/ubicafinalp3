using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Ubicua_Lectura_de_Datos.Db;
using System.Globalization;

namespace Ubicua_Lectura_de_Datos.Utils
{
    public class UtilCom : IDisposable
    {
        private readonly string _com;
        private readonly SerialPort _port;
        private readonly int buffer = 0;

        public UtilCom(string com)
        {
            _com = com;
            _port = new SerialPort(com, 9600);
            _port.Open();

            _port.DiscardOutBuffer();
            _port.DiscardInBuffer();

            AppDomain.CurrentDomain.ProcessExit += (sender, e) => CerrarPuertoCom();
        }

        private void CerrarPuertoCom()
        {
            // Acciones que se ejecutarán al finalizar la aplicación
            if (_port.IsOpen)
            {
                _port.Close();
            }
        }
        public Dato leer()
        {

            Dato recibido = null;

            if (_port.BytesToRead > 27)
            {
                try
                {
                    string data = _port.ReadLine();
                    string[] valores = data.Split(':');

                    float gx = float.Parse(valores[0], CultureInfo.InvariantCulture),
                          gy = float.Parse(valores[1], CultureInfo.InvariantCulture),
                          gz = float.Parse(valores[2], CultureInfo.InvariantCulture),
                          temp = float.Parse(valores[3], CultureInfo.InvariantCulture),
                          hum = float.Parse(valores[4], CultureInfo.InvariantCulture);

                    recibido = new Dato
                    {
                        gx = gx,
                        gy = gy,
                        gz = gz,
                        temp = temp,
                        hum = hum,
                        date = DateTime.Now
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return recibido;
        }

        public void Dispose()
        {
            CerrarPuertoCom();
        }
    }
}
