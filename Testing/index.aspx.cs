using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    // ----Servicios Soap

    protected void btnCovnertir_Click(object sender, EventArgs e)
    {
        localhost.servicios localhost_servicios = new localhost.servicios();

        bool convert = radCm.Checked;
        double valor = Convert.ToDouble(Request.Form["txtValor"]);
        
        if (convert)
        {
            lblConvertido.Text = localhost_servicios.Centrimeto_a_pulgada(valor).ToString();
        }
        else
        {
            lblConvertido.Text = localhost_servicios.Pulgada_a_centimetro(valor).ToString();
        }
    }
    protected void btnSigloAño_Click(object sender, EventArgs e)
    {
        localhost.servicios localhost_servicios = new localhost.servicios();

        int año = Convert.ToInt32(Request.Form["txtAño"]);
        lblSiglo.Text = localhost_servicios.Siglo_de_un_año(año).ToString();
    }

    // ----Servicios Rest

    // GET
    protected void btnGet_Click(object sender, EventArgs e)
    {
        string api = txtApi.Text;
        string id = txtGet.Text;
        string url = api + "/" + id;

        // Lector de Json, GetId
        WebClient cliente = new WebClient();
        byte[] data = cliente.DownloadData(url);
        Stream memo = new MemoryStream(data);
        var reader = new StreamReader(memo);
        var resultado = reader.ReadToEnd();
        
        Response.Write("GET:" + resultado);
    }

    // GETALL
    protected void betGetAll_Click(object sender, EventArgs e)
    {
        string api = txtApi.Text;

        // Lector de Json, GetAll
        WebClient cliente = new WebClient();
        byte[] data = cliente.DownloadData(api);
        Stream memo = new MemoryStream(data);
        var reader = new StreamReader(memo);
        var resultado = reader.ReadToEnd();

        Response.Write("GETALL:" + resultado);
    }

    // POST
    protected void btnPost_Click(object sender, EventArgs e)
    {
        string api = txtApi.Text;
        string nombre = txtPostNombre.Text;
        string apellido = txtPostApellido.Text;

        // Insert Json como string
        WebClient cliente = new WebClient();
        string json_str = "{'nombre': '"+nombre+"', 'apellido': '"+apellido+"'}";
        byte[] data = Encoding.ASCII.GetBytes(json_str);
        cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
        byte[] resultado = cliente.UploadData(api, data);

        Response.Write("POST:" + Encoding.ASCII.GetString(resultado));
    }

    // PUT
    protected void btnPut_Click(object sender, EventArgs e)
    {
        string api = txtApi.Text;
        string id = txtPutId.Text;
        string nombre = txtPutNombre.Text;
        string apellido = txtPutApellido.Text;
        string url = api + "/" + id;

        // Upload con uploadData
        WebClient cliente = new WebClient();
        string json_str = "{'id': " + id + ", 'nombre': '" + nombre + "', 'apellido': '" + apellido + "'}";
        byte[] data = Encoding.ASCII.GetBytes(json_str);
        cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
        byte[] resultado = cliente.UploadData(url, "PUT", data);

        Response.Write("PUT:" + json_str);
    }

    // DELETE
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string api = txtApi.Text;
        string id = txtDelete.Text;
        string url = api + "/" + id;

        // Delete con uploadValues
        WebClient cliente = new WebClient();
        byte[] resultado = cliente.UploadValues(url, "DELETE", new NameValueCollection());

        Response.Write("DELETE:" + Encoding.ASCII.GetString(resultado));
    }
}