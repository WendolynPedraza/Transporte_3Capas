<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Camiones.aspx.cs" Inherits="Transporte_3Capas.Catalogos.Camiones.Listado_Camiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Listado de camiones</h3>
            <%---boton para agregar un nuevo camion---%>
            <p>
                <%--SearchExpression genera un evento click---%>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">
    <asp:GridView ID="GVCamiones" runat="server" CssClass="table table-bordered table-bordered table-condensed"
        AutoGenerateColumns="false"
        DataKeyNames="ID_Camion"
        OnRowDeleting="GVCamiones_RowDeleting"
        OnRowCommand="GVCamiones_RowCommand"
        OnRowEditing="GVCamiones_RowEditing"
        OnRowUpdating="GVCamiones_RowUpdating"
        OnRowCancelingEdit="GVCamiones_RowCancelingEdit">
        <%--arriba se generan los eventos "onrow"--%>
        <Columns>
            <asp:BoundField DataField="ID_Camion" HeaderText=" Numero de Camion" ItemStyle-Width="50px" ReadOnly="true"/>

            <asp:BoundField DataField="Matricula" HeaderText="Matricula" AccessibleHeaderText="matricula" ItemStyle-Width="85px" />

            <asp:BoundField DataField="Tipo_Camion" HeaderText="tipo_camion" ItemStyle-Width="50px" />

            <asp:BoundField DataField="Disponibilidad" ItemStyle-Width="50px" />

                <asp:TemplateField HeaderText ="Disponibilidad" ItemStyle-Width="50px">
                <ItemTemplate>
                    <div style="width: 100%">
                        <div style="width: 25%; margin: 0 auto">
                            <asp:CheckBox ID="chkDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>' Enabled="false" />
                        </div>
                    </div>
                </ItemTemplate>

                <EditItemTemplate>
                    <div style="width: 100%">
                        <div style="width: 25%; margin: 0 auto">
                            <asp:CheckBox ID="chkEditDisponible" runat="server" Checked='<%#Eval("Disponibilidad")%>' />
                        </div>
                    </div>
                </EditItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="UrlFoto" HeaderText="urlFoto" ItemStyle-Width="85px" />

                <asp:ImageField HeaderText="Foto" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="urlFoto"></asp:ImageField>

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                
                 <asp:CommandField ButtonType="Button" HeaderText="3" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
        </Columns>
    </asp:GridView>
     </div>
    </div>
</asp:Content>
