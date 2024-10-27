<%@ Page Language="C#"  AutoEventWireup="true"  CodeBehind="json.aspx.cs"  Inherits="Json" %>
<%= new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ViewData) %>