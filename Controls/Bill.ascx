<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Bill.ascx.cs" Inherits="Controls_Bill" %>

 <style type="text/css" media="all">
        .SideUpperLabel
        {
          font-family:@Arial Unicode MS;
          font-size:large;
          color:Navy !important;
          -webkit-print-color-adjust: exact; 
          padding-left:5px;
          padding-top:4px;
          font-weight:normal;   
        }
         td
        {
            font-family:Verdana; 
         
            
        }
        .tabStyle
        {
          min-width:700px !important;
           -webkit-print-color-adjust: exact; 
          max-width:1000px !important;
        }
        .tplbl
        {
         background-color:#FFFF99 !important;
         -webkit-print-color-adjust: exact;  
        }
        .billQ
        {
           font-weight:bolder; 
           vertical-align:top;
        }
        .billA
        {
          color:Gray;
          line-height:25px;
          padding-left:10px;
          padding-right:20px;
          vertical-align:top;
        }
        .calculations
        {
             width:100%;   
        }
        
     .style1
     {
         width: 32%;
     }
     .style2
     {
         width: 33%;
     }
        
    </style>


 <table class="tabStyle" id="printingDiv">
         <tr>
                <td class="style2" >
                <img src="../images/iiitd_logo.png" height="50px" alt="IIITD"/>
                                   </td>
                <td style="font-size:x-large;" class="style1">
                    ELECTRICITY BILL</td>
                
                <td class="tplbl" style="width:300px;">
                    <p id="billAmount" runat="server" class="SideUpperLabel"></p>
                   
                    <p id="dueDate" runat="server" class="SideUpperLabel"></p>
                </td>
            </tr>
            <tr style="vertical-align: top; ">
                
                <td class="style2">   <label runat="server" id="fullName" class="billHead"></label>
                   <label runat="server" id="address" class="billHead2"></label>
                   <label runat="server" id="mobile" class="billHead2"></label>
                        
                    
                    </td>
            
                <td colspan="2">                   
                                                              
               <h4 id="headingTip" runat="server"></h4>    
               <p id="headingText" runat="server"></p>                    
                      
                   </td>
              
            </tr>
            <tr style=" background-color:#f6f0f0 !important; opacity:0.85;">
                <td class="style2">
                <h4 >Billing Details:</h4>
                <h5>
                  Meter No. &nbsp;&nbsp;<label runat="server" id="meterNo" class="billA"></label>
                  Bill No.  &nbsp;&nbsp;  <label runat="server" id="billNo" class="billA"></label>
                  Bill Period &nbsp;&nbsp;  <label runat="server" id="billPeriod" class="billA"></label>
                  Bill Date &nbsp;&nbsp; <label runat="server" id="billDate" class="billA"></label>
                  </h5>
                    </td>
                <td class="style1">
                <h5>
                 Power Factor &nbsp;&nbsp;<label class="billA">0.9</label>
                 Sanctioned Load &nbsp;&nbsp;<label class="billA">8 Kva</label>
                 MDI &nbsp;&nbsp;<label class="billA">1</label>
                 Supply Type&nbsp;&nbsp;<label class="billA">LT</label>
                 </h5>

                    </td>
                <td style="vertical-align:top;">
                    <h5><br />
                 Meter Status &nbsp;&nbsp;<label class="billA">OK</label>
                 Meter Type &nbsp;&nbsp;<label class="billA">Permanent</label>
                 Energisation Date &nbsp;&nbsp;<label class="billA"></label>
                 </h5>
                    
                   </td>
            
            </tr>
            <tr style=" background-color:#f6f0f0 !important; opacity:0.85;">
                <td colspan="3">
                 
                    <table>
                        <tr>                    
                            <td >
                            
                                <table style="border: thin groove #000000"  class="calculations"><tr><td class="billQ">
                                Meter Type
                                </td>
                                <td class="billQ">
                                
                                Units Consumed
                                </td>
                                <td class="billQ" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Readings
                                <br />Initial &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;Final
                                
                                </td>
                                <td class="billQ">
                                Total Units
                                
                                </td>
                                </tr>
                                <tr>
                                <td class="billA">
                                    <asp:Label ID="meterType1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units0" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp1Units1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="totalUnits" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                <td class="billA">
                                    <asp:Label ID="meterType2" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units0" runat="server"></asp:Label>
                                    </td>
                                <td class="billA">
                                    <asp:Label ID="metTyp2Units1" runat="server"></asp:Label>
                                    </td>
                                <td class="billA" runat="server" id="dayTd">
                                    
                                    </td>
                                </tr>
                                
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="border: thin groove #000000"  class="calculations">
                                    <tr>
                                        <td class="billQ">
                                            Units Consumed
                                            </td>
                                        <td class="billQ">
                                            Price Cal. (Slab-wise)</td>
                                        <td class="billQ">
                                            
                                            Fixed Charge(per day)
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="billA">
                                            <asp:Label ID="totalUnitsConsumed" runat="server"></asp:Label>
                                        </td>
                                        <td id="slabText" runat="server"  class="billA">
                                            
                                        </td>
                                        <td id="fixedText" runat="server"  class="billA">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Total</td>
                                        <td class="billA">
                                            <asp:Label ID="totalSlabCharge" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="totalFixCharge" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="border: thin groove #000000" class="calculations">
                                    <tr>
                                        <td class="billQ">
                                            Tax Eval on</td>
                                        <td class="billQ">
                                            Price</td>
                                        <td class="billQ">
                                            Adj. Charges(1.5%)</td>
                                        <td class="billQ">
                                            Def. Charges(8%)</td>
                                        <td class="billQ">
                                            Total</td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Energy Charge</td>
                                        <td class="billA">
                                            <asp:Label ID="energyChrg" runat="server"></asp:Label>
                                            </td>
                                        <td class="billA">
                                            <asp:Label ID="adjEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="defEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="netEnrgyChrg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="billQ">
                                            Fixed Charge</td>
                                        <td class="billA">
                                            <asp:Label ID="fixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="adjFixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="defFixChrg" runat="server"></asp:Label>
                                        </td>
                                        <td class="billA">
                                            <asp:Label ID="netFixChrg" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="billQ">
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="billQ">
                                            <asp:Label ID="subTotalTxt" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td id="elecTax" runat="server">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td runat="server" id="netBillAmt">
                                &nbsp;</td>
                        </tr>
                    </table>
                  
                  
                  
                  
                  </td>
            </tr>
            <tr >
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            
            </tr>
        </table>

         <hr style="color:White;" />