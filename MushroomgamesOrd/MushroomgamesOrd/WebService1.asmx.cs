using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MushroomgamesOrd
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://servicioMushroom.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string ObtenerInformacionProyeto()
        {
            return "Nombre del proyecto: Mushroomgames, Creado por: Rey Juan Rendon Herrera, Materia: Programacion web";
        }

        [WebMethod]
        public Double ObtenerDescuentos(String cantidad, String descuento)
        {
            Double num1 = Int32.Parse(cantidad);
            Double num2 = Int32.Parse(descuento);
            Double resultado = num1 - num2;

            return resultado;
        }

        [WebMethod]
        public List<String> ObtenerNombreVideojuegos()
        {
            List<String> list = new List<String>();

            using (var contexto = new MushroomgamesDBEntities()) {

                var consulta = (from x in contexto.Juego
                                select x.nombre_Juego);

                foreach (var nombre in consulta) {
                    list.Add(nombre);

                }

            }

                return list;
        }

    }
}
