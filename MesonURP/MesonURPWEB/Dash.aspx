<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dash.aspx.cs" Inherits="MesonURPWEB.WebForm2" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Chart ID="Chart1" runat="server" Height="409px" Width="618px">
        <Series>
            <asp:Series Name="Series1" ChartType="Bar" IsValueShownAsLabel="True" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <%--<Legends>
            <asp:Legend Alignment="Center" AutoFitMinFontSize="10" BorderColor="Maroon" BorderWidth="3" Docking="Bottom" Font="Microsoft Sans Serif, 10pt" HeaderSeparator="DoubleLine" IsTextAutoFit="False" ItemColumnSeparator="DoubleLine" Name="Legend1" TableStyle="Wide" Title="Leyenda">
                <CellColumns>
                    <asp:LegendCellColumn HeaderText="Nom" Name="Column1">
                        <Margins Left="15" Right="15" />
                    </asp:LegendCellColumn>
                    <asp:LegendCellColumn HeaderText="Total" Name="Column2" Text="#TOTAL">
                        <Margins Left="15" Right="15" />
                    </asp:LegendCellColumn>
                    <asp:LegendCellColumn HeaderText="Top" Name="Column3" Text="#MAX">
                        <Margins Left="15" Right="15" />
                    </asp:LegendCellColumn>
                    <asp:LegendCellColumn ColumnType="SeriesSymbol" HeaderText="Sim" Name="Column4" Text="">
                        <Margins Left="15" Right="15" />
                    </asp:LegendCellColumn>
                </CellColumns>
            </asp:Legend>
        </Legends>--%>
        <Titles>
            <asp:Title Font="Microsoft Sans Serif, 16pt" Name="Title1">
            </asp:Title>
        </Titles>
   </asp:Chart>
</asp:Content>
