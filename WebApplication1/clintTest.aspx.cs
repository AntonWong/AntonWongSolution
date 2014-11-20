using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class clintTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //用一个WebClient就可以搞定了 
           // var client = new WebClient();

           // //以PUT方式访问Data/1/100，会映射到服务端的CreateData("1", "100") 
           //// client.UploadString(http://localhost:5335/Service1.svc/data/1", "PUT", string.Empty);
           // string str = client.DownloadString("http://192.168.18.3:8089/Services/CarModelService.svc/GetCarCountries");
           // //以GET方式访问Data/1，会映射到服务端的RetrieveData("1")，应该返回"100" 
           // Response.Write(str);

          //  var param = new { id= new Guid(),name = "Wang"};
      //      Response.Write(client.DownloadString("http://localhost:5335/Service1.svc/data/1/" + param));
            //以POST方式访问Data/1/200，会映射到服务端的UpdateData("1", "200")             
            // client.UploadString("http://localhost:8080/wcf/Data/1/200", "POST", string.Empty);

            //再GET一次，应该返回"200" 
            //   Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));

            //以DELETE方式访问Data/1，会映射到服务端的DeleteData("1") 
            //  client.UploadString("http://localhost:8080/wcf/Data/1", "DELETE", string.Empty);
            //
            //再GET一次，应该返回"NOT FOUND" 
            // Console.WriteLine(client.DownloadString("http://localhost:8080/wcf/Data/1"));

            //WebRequest request = WebRequest.Create("http://localhost:5335/Service1.svc/data/1");
            //request.Method = "Get";
            //request.ContentType = "application/x-www-form-urlencoded";
            //WebResponse webResponse = request.GetResponse();
            //Stream receiveStream = webResponse.GetResponseStream();
            //StreamReader srdPreview = new StreamReader(receiveStream, Encoding.UTF8);
            //byte[] strBt = new byte[receiveStream.Length];
            //Encoding.UTF8.GetString(strBt);
          
        }
    }
}