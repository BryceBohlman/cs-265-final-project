<%@ Page Title=""
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Cars.aspx.cs" 
    Inherits="csis265final.Cars" 
    EnableEventValidation ="false"
    %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
<p>
    <asp:HiddenField ID="hdnId" runat="server" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Car Data" Font-Bold="True"></asp:Label>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Make:  "></asp:Label>
    <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label3" runat="server" Text="Model:  "></asp:Label>
    <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Color:  "></asp:Label>
    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="Weight:  "></asp:Label>
    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Mpg:  "></asp:Label>
    <asp:TextBox ID="txtMpg" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnAddCar" runat="server" Text="Add Car" OnClick="btnAddCar_Click1" />
</p>
<p>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Lime"></asp:Label>
</p>
<p>
    <asp:Label ID="Label7" runat="server" Text="Existing Cars" Font-Bold="True"></asp:Label>
</p>
<p>
    <asp:Repeater ID="rptData" runat="server">
            
            <HeaderTemplate>
                <Table>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblId" Text='<%#Eval("Id") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblMake" Text='<%#Eval("Make") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblModel" Text='<%#Eval("Model") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblColor" Text='<%#Eval("Color") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblWeight" Text='<%#Eval("Weight") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblMpg" Text='<%#Eval("Mpg") %>' ></asp:Label>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnEdit" Text='Edit' OnClick="btnEdit_Click" ></asp:Button>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnDelete" Text='Delete' OnClick="btnDelete_Click" ></asp:Button>
                    </td>
                </tr>

            </ItemTemplate>


            <FooterTemplate>
                </Table>
            </FooterTemplate>
        </asp:Repeater>
</p>
</asp:Content>
