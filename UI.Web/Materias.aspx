﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="container">
        <asp:Label ID="Label1" runat="server" Text="ALTAS, BAJAS Y MODIFICACIONES DE MATERIAS"></asp:Label>
    </div>
    
    <div id="margen"></div>
	<section id="content">
		<asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="gvMaterias" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" OnSelectedIndexChanged="gvMaterias_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion"/>
                        <asp:BoundField DataField="HSSemanales" HeaderText="HS Semanales"/>
                        <asp:BoundField DataField="HSTotales" HeaderText="HS Totales"/>
                        <asp:BoundField DataField="IDPlan" HeaderText="ID Plan"/>
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />

                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <asp:LinkButton ID="editarlinkButton" runat="server" OnClick="editarlinkButton_Click">Editar</asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Agregar</asp:LinkButton>
            </asp:Panel>
    </section>
    
    <div CssClass="aside">
        <asp:Panel ID="formPanel" runat="server" Visible="False">
                        <table border="1" align="right">
						    <tr>
							    <td align="center" colspan="2">
							        <strong>
                                    <asp:Label ID="lblTitulo" runat="server" Text="DATOS"></asp:Label>
                                    </strong></td>
						    </tr>
						    <tr>
							    <td align="right"><asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label></td>
                                <td><asp:TextBox ID="txtDescripcion" runat="server" />
                                    <asp:RequiredFieldValidator ID="descripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="La descripción no puede ser vacía" ForeColor="Red"  Text="*"   />
                                </td>
						    </tr>
				            <tr>
                                <td align="right"><asp:Label ID="lblHsSemanales" runat="server" Text="Hs Semanales: "></asp:Label></td>
                                <td><asp:TextBox ID="txtHsSemanales" runat="server" />
                                    <asp:RequiredFieldValidator ID="hssemanales" runat="server" ControlToValidate="txtHsSemanales" ErrorMessage="Las hs semanales no pueden ser vacía" ForeColor="Red"  Text="*"   />
                                </td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblHsTotales" runat="server" Text="Hs Totales: "></asp:Label></td>
                                <td><asp:TextBox ID="txtHsTotales" runat="server" />
                                    <asp:RequiredFieldValidator ID="hstotales" runat="server" ControlToValidate="txtHsTotales" ErrorMessage="Las hs totales no pueden ser vacía" ForeColor="Red"  Text="*"   />
                                </td>
                            </tr>
                            <tr>
							    <td align="right"><asp:Label ID="lblPlan" runat="server" Text="ID Plan: "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlIdPlan" runat="server" Width="100%"></asp:DropDownList>
                                </td>
						    </tr>
                            <tr>
							    <td align="right" colspan="2">
								    <asp:Panel ID="formActionsPanel" runat="server">
									    <asp:LinkButton ID="lnkbtnCancelar" runat="server" OnClick="lnkbtnCancelar_Click" CausesValidation="false">Cancelar </asp:LinkButton>
									    <asp:LinkButton ID="lnkbtnAceptar" runat="server" OnClick="lnkbtnAceptar_Click" OnClientClick = "return confirm('¿Desea guardar los cambios ?');"> Aceptar</asp:LinkButton>
									    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
								    </asp:Panel>
							    </td>
						    </tr>
					    </table>
            </asp:Panel>
    </div>

</asp:Content>
