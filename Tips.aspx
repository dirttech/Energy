<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tips.aspx.cs" Inherits="Tips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
 h1
 {
     font-size:xx-large;
   <%--color:skyblue; 
     --%>
     
 }
.tipsUL
{
   display:none;   
   background-color:White;
   width:100%;
}
.tips
{
   cursor:pointer;   
   background-color:#f6f0f0;
   margin-top:10px;
}
.tips-icons
{
  height:150px;   
}
.opcl
{
  height:30px;
  width:30px;   
  
}

</style>
<script type="text/jscript">

    jQuery(document).ready(function ($) {

        $('.tips').click(function () {

            if (!$(this).find('table').is(':visible')) {
                $(this).find("table").fadeIn('slow', function () {
                    // Animation complete.
                });
            }
            else
            {

                $(this).find("table").fadeOut('slow', function () {
                    // Animation complete.
                });
            }

        });

        $('.tipsUL').click(function ($) {
            $('.tipsUL').toggle('slow', function () {
                // Animation complete.
            }); ;
        });



    });
       

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="contra">
<h1 style="color:skyblue;">Energy Saving Tips</h1>
<p>Wondering about ways to reduce your energy consumption? Try some of these energy-saving ideas!</p>
<div class="tips">
<h1>Lights</h1>
<table  class="tipsUL"><tr><td>
<ul type="disc">
<li>Turning Lights off when not in use
</li>
<li>Use T5 fluorescent tube light fittings.
</li>
<li>LEDs are the most effective lights and their life
is not impacted by frequency of switching on
and off.</li>
<li>Use task lighting; instead of brightly lighting an
entire room, focus the light where you need it</li>

</ul>
</td>
<td><img src="images/tips-icons/cflF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div>
<%--<img alt="" src="images/tips-icons/plusF.png" class="opcl"/><img alt="" src="images/tips-icons/minusF.png" class="opcl"/>--%>
<div class="tips">
<h1>Television</h1>
<table class="tipsUL"><tr><td>
<ul type="disc" >
<li>LCDs and LEDs are better than CRT and Plasma.
Rear projector Televisions are the most efficient
ones.
</li>
<li>Select size of the television according to the
room size
</li>
<li>Set Appropriate Picture settings to save
electricity.</li>
<li>Prefer a non HD TV as it consumes less energy
than a HD TV.</li>

</ul>
</td>
<td><img src="images/tips-icons/tvF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div>
<div class="tips">
<h1>Refrigerator</h1>
<table class="tipsUL"><tr><td>
<ul type="disc" >
<li>Regularly defrost manual-defrost refrigerators and
freezers; frost build up increases the amount of energy
needed to keep the motor running.
</li>
<li>Don't keep your refrigerator or freezer too cold.
</li>
<li>Make sure your refrigerator door seals are airtight</li>
<li>Cover liquids and wrap foods stored in the refrigerator.</li>
<li>Do not open the doors of the refrigerators frequently</li>
<li>Avoid putting hot or warm food straight into the fridge.</li>

</ul>
</td>
<td><img src="images/tips-icons/fridgeF.png" alt="" /></td>
</tr></table>
</div>
<div class="tips">
<h1>Washing Machine</h1>
<table class="tipsUL"><tr><td>
<ul type="disc" >
<li>A front loading washing machine is always more efficient
than a top load washing machine.
</li>
<li>Always try to use washing machine with full load, as the
electricity used is same even if you under-load the
washing machine.
</li>
<li>Buy the right detergent and use the right amount</li>
<li>Never leave washing machine in standby mode.</li>

</ul>
</td>
<td><img src="images/tips-icons/washing-machineF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div>
<div class="tips">
<h1>Microwave Oven</h1>
<table class="tipsUL"><tr><td>
<ul type="disc" >
<li>Consumes 50 % less energy than conventional electric
/ gas stoves.
</li>
<li>Do not bake large food items.
</li>
<li>Unless you're baking breads or pastries, you may not
even need to preheat.</li>
<li>Don't open the oven door too often to check food
condition as each opening leads to a temperature
drop of 25°C.</li>
</ul>
</td>
<td><img src="images/tips-icons/ovenF.png" alt="" class="tips-icons"/></td>
</tr></table>

</div>
<div class="tips">
<h1>Air Conditioner</h1>
<table class="tipsUL"><tr><td>
<ul type="disc" >
<li>Prefer air conditioner having automatic temperature cut off.
</li>
<li>Leave enough space between your air conditioner and the walls to allow better air
circulation.
</li>
<li>Set your thermostat as high as comfortably possible in the summer. The less
difference between the indoor and outdoor temperatures, the lower will be energy
consumption. Temperature setting of close to 28oC can reduce your energy
consumption of AC by almost half.</li>
<li>Don't place lamps or TV sets near your air- conditioning thermostat.</li>

</ul>
</td>
<td><img src="images/tips-icons/airConF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div>
<div class="tips">
<h1>Computers</h1>
<table class="tipsUL"><tr><td>
<ul type="disc">
<li>Enabling power management features on
the computer.
</li>
<li>Use a laptop rather than a desktop. Using
a laptop can save about 50% or more of
electricity.
</li>
<li>If you just need net surfing, use a tablet
(low powered processors that consume
less electricity).</li>
<li>Use Low power chips like Intel Atom that
provides same performance with less
power consumption.</li>

</ul>
</td>
<td><img src="images/tips-icons/computerF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div>
<div class="tips">
<h1>Mixers</h1>
<table class="tipsUL"><tr><td>
<ul type="disc">
<li>Avoid dry grinding in your food processors (mixers and grinders) as it takes longer time than
liquid grinding.
</li>
</ul>
</td>
<td><img src="images/tips-icons/mixerF.png" alt="" class="tips-icons"/></td>
</tr></table>
</div> 
</div>

</asp:Content>

