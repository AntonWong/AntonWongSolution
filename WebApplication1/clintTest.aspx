<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clintTest.aspx.cs" Inherits="WebApplication1.clintTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<script src="Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
            //$.getJSON("http://192.168.18.3:8089/Services/CarModelService.svc/GetCarCountries?id=0&jsoncallback=?", {}, function (json) {
            $.getJSON("http://192.168.18.3:8089/Services/CarModelService.svc/GetCarCountries?tags=cat&tagmode=any&format=json&jsoncallback=?", function (data) {
                console.log(json);
                
            });
            //$.ajax({
            //    contentType: "application/x-www-form-urlencoded",
            //    type: "get",
            //    async: false,
            //    url: "http://localhost:12821/Services/CarModelService.svc/GetCarCountries?callback=?",
            //    dataType: "html",
            //    jsonp: "callbackparam",//传递给请求处理程序或页面的，用以获得jsonp回调函数名的参数名(默认为:callback)
            //    jsonpCallback: "success_jsonpCallback",//自定义的jsonp回调函数名称，默认为jQuery自动生成的随机函数名
            //    success: function (json) {
            //        alert(json);
            //    },
            //    error: function () {
            //        alert('fail');
            //    }
            //});
     
    </script>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
