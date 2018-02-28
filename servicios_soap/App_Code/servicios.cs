using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for servicios
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class servicios : System.Web.Services.WebService {

    public servicios () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    /*
    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    */
    [WebMethod]
    public double Centrimeto_a_pulgada(double cm)
    {
        return cm / 2.54;
    }

    [WebMethod]
    public double Pulgada_a_centimetro(double pul)
    {
        return pul * 2.54;
    }

    [WebMethod]
    public int Siglo_de_un_año(int año)
    {
        if (año >= 1)
        {
            if (año % 100 == 0)
                return (año / 100);
            else
                return (año / 100) + 1;
        }
        else
            return 0; 
    }
}
