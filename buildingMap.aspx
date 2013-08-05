<%@ Page Language="C#" AutoEventWireup="true" CodeFile="buildingMap.aspx.cs" Inherits="buildingMap" %>
<html>
<head>
    <title>OpenLayers Basic Example</title>

    <script src="http://www.openlayers.org/api/OpenLayers.js"></script>
    <script src="BuildingsLayer.js"></script>
    <script>
        function init() {
            map = new OpenLayers.Map("mapdiv");
            var mapnik = new OpenLayers.Layer.OSM(
            
            
            );
            map.addLayer(mapnik);

            var lonlat = new OpenLayers.LonLat(77.27277, 28.54648).transform(
            new OpenLayers.Projection("EPSG:4326"), // transform from WGS 1984
            new OpenLayers.Projection("EPSG:900913"),
            map.getProjectionObject() // to Spherical Mercator
          );



            var zoom = 17;
           
            var markers = new OpenLayers.Layer.Markers("Markers");
            map.addLayer(markers);
            markers.addMarker(new OpenLayers.Marker(lonlat));

            map.setCenter(lonlat, zoom);

            

            var layer = new OpenLayers.Layer.Vector("Polygon", {
                strategies: [new OpenLayers.Strategy.Fixed()],
                protocol: new OpenLayers.Protocol.HTTP({
                    url: "mapnew.osm",   //<-- relative or absolute URL to your .osm file
                    format: new OpenLayers.Format.OSM()
                }),
                projection: new OpenLayers.Projection("EPSG:4326")
            });
            map.addLayers([layer]);

            layer.load();

            var osmb = new OpenLayers.Layer.Buildings();
            map.addLayer(osmb);

            var data = {
                "type": "FeatureCollection",
                "features": [{
                    "type": "Feature",
                    "geometry": {
                        "type": "Polygon",
                        "coordinates": [[
                [77.27290, 28.54640],
                [77.27295, 28.54640],
                [77.27295, 28.54648],
                [77.27290, 28.54648],
                [77.27290, 28.54640]
            ]]
                    },
                    "properties": {
                        "wallColor": "rgb(255,0,0)",
                        "height": 500
                    }
                }]
            };

            osmb.geoJSON(data);
         
            osmb.load();

        }
    </script>

    <style>
    #mapdiv { width:1050px; height:650px; }
    div.olControlAttribution { bottom:3px; }
    </style>

</head>

<body onload="init();">
    <div id="mapdiv"></div>
</body>
</html>