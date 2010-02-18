<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
Home
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

    
  

    <h2>Search for something</h2>
    <form action="/Home/Search" method="post" id="searchForm">
      <input type="text" name="searchTerm" id="searchTerm" value="" size="10" maxlength ="30" />
      <input type ="submit" value="Search" />
    </form>
    <br />

</asp:Content>
