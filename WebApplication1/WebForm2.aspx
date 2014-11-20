<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery.signalR-2.1.2.js"></script>
    <script src="/signalr/hubs"></script>
    <script>
        $(function () {
            var chat = $.connection.AdminHub;
            alert(chat);
            chat.client.addMessage = function (message) {
                alert(message);
            };
            $.connection.hub.start();
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      
    </div>
    </form>
</body>

</html>

