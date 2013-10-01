<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>User Registration Form</title>
    <script src="jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function() 
    {
        function getStates()
        {            
          $.post("GeoLocationHandler.ashx?StrMethodName=GETSTATES", { DdlCountry : $("#DdlCountry option:selected").text() }, 
            function (response) 
            {
                $("#DdlState").html(response);
                getCities();
            });
        }
        function getCities()
        {            
          $.post("GeoLocationHandler.ashx?StrMethodName=GETCITIES", { DdlState : $("#DdlState option:selected").text() }, 
            function (response) 
            {
                $("#DdlCity").html(response);
            });
        }
        function registerUser()
        {
            $.post("GeoLocationHandler.ashx?StrMethodName=REGISTERUSER", 
            {
                DdlCountry: $("#DdlCountry option:selected").text(),
                DdlState: $("#DdlState option:selected").text(),
                DdlCity: $("#DdlCity option:selected").text(),
                TxtFirstName: $("#TxtFirstName").val(),
                TxtMiddleName: $("#TxtMiddleName").val(),
                TxtLastName: $("#TxtLastName").val(),
                TxtEmail: $("#TxtEmail").val()
            }, function(response) { $("#DivResponse").html(response); });
            return false; 
        }
        $.post("GeoLocationHandler.ashx?StrMethodName=GETCOUNTRIES", {}, 
                function (response) 
                {
                  $("#DdlCountry").html(response);
                  getStates();
                });
        $("#DdlCountry").change(getStates);
        $("#DdlState").change(getCities);        
        $("#BtnRegister").click(registerUser);
    });
    </script>
</head>
<body style="font-family: Verdana;">
    <form id="form1" action="">
    <div>
    <table cellpadding="5" cellspacing="2" style="border-collapse: collapse; border: solid 1px #000;">
    <tr>
        <th>Country</th><th>State</th><th>City</th>
    </tr>
    <tr>
        <td><select id="DdlCountry" name="DdlCountry" ><option>loading countries...</option></select></td>
        <td><select id="DdlState"><option>loading states...</option></select></td>
        <td><select id="DdlCity"><option>loading cities...</option></select></td>
    </tr>
    <tr>
        <th>First Name</th><th>Middle Name</th><th>Last Name</th>
    </tr>
    <tr>
        <td><input id="TxtFirstName" type="text" /></td><td><input id="TxtMiddleName" type="text" /></td><td><input id="TxtLastName" type="text" /></td>
    </tr>
    <tr>
        <th>Email</th><td><input id="TxtEmail" type="text" /></td><td><input id="BtnRegister" type="submit" value="Register" /></td>
    </tr>
    </table>
    </div>
    <div id="DivResponse"></div>
    </form>
</body>
</html>
