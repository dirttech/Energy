<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillConfiguration.aspx.cs" Inherits="admin_BillConfiguration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Settings</title>

    <link rel="shortcut icon" href="../images/dashboard_icon.png" />
    <link rel="Stylesheet" type="text/css" media="screen" href="../Scripts/Default.css" />
     <link rel="stylesheet" type="text/css" media="screen" href="../Scripts/calender/bootstrap-datetimepicker.min.css" />
     <link href="http://netdna.bootstrapcdn.com/twitter-bootstrap/2.2.2/css/bootstrap-combined.min.css" rel="stylesheet" / >
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
   
    <style type="text/css">
        input[type="text"]
        {
            margin-left:30px;
            
        }
        textarea
        {
            margin-left: 30px;
        }
        input[type="number"]
        {
             margin-left:30px;
        }
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
            <div class="HeadingLeftTop" style="opacity: 0.9; width: 300px">
                <label id="Heading" runat="server" style="font-size: x-large;">Bill Settings</label>
                <label id="subHeading" runat="server" style="font-size: small;">All the Taxes/Charges should be "Monthly".</label>
            </div>
        </div>
        <br />
        <table>
            <tr>
                <td>Applicable Date</td>
                <td>
                     <div id="datetimepicker1" class="input-append date">
                  <input type="text" id="fromDate" runat="server" style=" margin-left:30px;"  required = "required"/>
      

                  <span class="add-on">
                    <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                  </span>
                </div>      
                </td>
                 <td>
                       </td>
            </tr>
            <tr>
                <td>Fixed Charge</td>
                <td>
                    <asp:TextBox ID="fixedCharge" runat="server"  required = "required" pattern="[0-9.]+"></asp:TextBox>
                </td>
                 <td>
                        </td>
            </tr>
             <tr>
                <td>Adj. Charge</td>
                <td>
                    <asp:TextBox ID="adjCharge" runat="server"  required = "required" pattern="[0-9.]+"></asp:TextBox>
                </td>
                 <td>
                      </td>
            </tr>
            <tr>
                <td>Def. Revenue Recovery Charge</td>
                <td>
                    <asp:TextBox ID="defCharge" runat="server" pattern="[0-9.]+"  required = "required"></asp:TextBox>
                </td>
                 <td>
                          </td>
            </tr>
            <tr>
                <td>Electricity Tax</td>
                <td>
                    <asp:TextBox ID="electricityTax" runat="server"  required = "required" pattern="[0-9.]+"></asp:TextBox>
                </td>
                 <td>
                       </td>
            </tr>
            <tr>
                <td>Number of Slabs</td>
                <td>
                    <asp:TextBox ID="slabSize" runat="server" AutoPostBack="True" type="number" OnTextChanged="slabSize_TextChanged"  required = "required"></asp:TextBox>
                </td>
                 <td>
                       </td>
            </tr>
            <tr>
                <td>
                <input type="hidden" id="slabsizes" runat="server" />
                <input type="hidden" id="slabprices" runat="server" />
                </td>
                <td runat="server" id="slabsizeBox" style="width:200px"></td>
                 <td runat="server" id="slabpriceBox" style="width:200px"></td>
            </tr>
            <tr>
                <td></td>
                <td align="left">
                    <asp:Button ID="SaveConfiguration" runat="server" Text="Submit" OnClick="SaveConfiguration_Click" CssClass="customButton" style="margin-left:30px;" OnClientClick="Save_Slabs()"/>
                </td>
                 <td><asp:Label ID="status" runat="server" ForeColor="#0033CC"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="left">
                    &nbsp;</td>
                 <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Visible="false">
                         <Columns>
                            <asp:BoundField DataField="ID" HeaderText="S.No." ReadOnly="True" SortExpression="ID"></asp:BoundField>
                            <asp:BoundField DataField="fixed_charge" HeaderText="Fixed Charge"></asp:BoundField>
                            <asp:BoundField DataField="adj_charge" HeaderText="Adj. Charge"></asp:BoundField>
                            <asp:BoundField DataField="def_charge" HeaderText="Def. Charge"></asp:BoundField>
                            <asp:BoundField DataField="electicity_tax" HeaderText="Electricity Tax"></asp:BoundField>
                            <asp:BoundField DataField="slab_size" HeaderText="Slab Size(ALL)"></asp:BoundField>
                            <asp:BoundField DataField="slab_price" HeaderText="Slab Price(ALL)"></asp:BoundField>
                            <asp:BoundField DataField="applicable_date" HeaderText="Applicable Date"></asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BillingAppConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:BillingAppConnectionString.ProviderName %>" SelectCommand="SELECT ID,fixed_charge,adj_charge,def_charge,electicity_tax,slab_size,slab_price,applicable_date FROM bill_settings"></asp:SqlDataSource>
                </td>
            </tr>
        </table>

    <script type="text/javascript"
     src="../Scripts/calender/jquery.min.js">
    </script> 
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.min.js">
    </script>
    <script type="text/javascript"
     src="../Scripts/calender/bootstrap-datetimepicker.pt-BR.js">
    </script>
    <script type="text/jscript">
        jQuery(document).ready(function ($) {
            $('#datetimepicker1').datetimepicker({
                format: 'dd/MM/yyyy hh:mm:ss',
                pick12HourFormat: true
            });
        });
    </script>    
          <script type="text/javascript">
              function Save_Slabs() {
                 var sizeSelect = document.getElementById('<%=slabsizeBox.ClientID%>').childNodes;

                 var sizetext = "";
                 for (var i = 0; i < sizeSelect.length; i++) {
                     sizetext = sizetext + sizeSelect[i].value + ",";
                 }
                 var priceSelect = document.getElementById('<%=slabpriceBox.ClientID%>').childNodes;
                 var pricetext = "";
                 for (var j = 0; j < priceSelect.length; j++) {
                    pricetext = pricetext + priceSelect[j].value+ ",";
                }
                
                 document.getElementById('<%=slabsizes.ClientID%>').setAttribute("value", sizetext);
                 document.getElementById('<%=slabprices.ClientID%>').setAttribute("value", pricetext);
        }
    </script>
    </form>
</body>
</html>
