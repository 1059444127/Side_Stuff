using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TransportSchedulesClasses
{
    public static class RouteProcessing
    {
        public static void ProcessRoutes(string fullPath)
        {
            XmlDocument routes = new XmlDocument();
            routes.Load(fullPath);

            var nodes = routes.DocumentElement.SelectNodes("/transportationNetwork/vehicleType");

            List<RouteStop> stops = new List<RouteStop>();
            List<RouteLine> lines = new List<RouteLine>();
            foreach (XmlElement vehicleTypeNode in nodes)
            {
                var currentId = vehicleTypeNode.Attributes["id"];
                int currentIDNumeric = int.Parse(currentId.Value);

                var stopsNode = vehicleTypeNode.FirstChild;
                var linesNode = vehicleTypeNode.LastChild;

                try
                {
                    GetStops(stopsNode, stops);

                    GetLines(linesNode, currentIDNumeric, lines, stops);
                }
                catch (NullReferenceException)
                {
                    throw new XmlException("Routes file invalid xml structure!");
                }
            }

            string dirPath = System.IO.Path.GetDirectoryName(fullPath);
            Directory.CreateDirectory(dirPath + "\\Processed Routes");

            #region XmlWriterSettings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            #endregion

            WriteProcessedRoutes(lines, dirPath, settings);
        }

        private static void WriteProcessedRoutes(List<RouteLine> lines, string dirPath, XmlWriterSettings settings)
        {
            foreach (var line in lines)
            {
                string currentPath = String.Format("{0}\\Processed Routes\\ID {1} Line {2}", dirPath, line.LineID, line);
                Directory.CreateDirectory(currentPath);
                foreach (var route in line.LineRoute)
                {
                    string fileName = String.Format("Line {0} - {1}", line, route);

                    using (XmlWriter writer = XmlWriter.Create(String.Format("{0}\\{1}.xml", currentPath, fileName), settings))
                    {
                        writer.WriteStartElement("transportationNetwork");
                        writer.WriteStartElement("vehicleType");
                        writer.WriteAttributeString("id", line.VehicleType.ToString());
                        writer.WriteStartElement("stops");

                        foreach (var stop in route.Stops)
                        {
                            writer.WriteStartElement("stop");
                            writer.WriteAttributeString("id", stop.PublicID.ToString());
                            writer.WriteAttributeString("code", stop.Code.ToString());
                            writer.WriteAttributeString("publicName", stop.Name);
                            writer.WriteAttributeString("lat", stop.DefaultLocation.Lat);
                            writer.WriteAttributeString("lon", stop.DefaultLocation.Lon);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteStartElement("lines");
                        writer.WriteStartElement("line");
                        writer.WriteAttributeString("id", line.LineID.ToString());
                        writer.WriteAttributeString("publicName", line.Name);
                        writer.WriteStartElement("route");
                        writer.WriteAttributeString("route_id", route.RouteID.ToString());
                        writer.WriteAttributeString("publicName", route.Name);

                        foreach (var stop in route.Stops)
                        {
                            writer.WriteStartElement("stopRef");
                            writer.WriteAttributeString("id", stop.PublicID.ToString());
                            writer.WriteEndElement();

                            foreach (var location in stop.StopLocations)
                            {
                                writer.WriteStartElement("point");
                                writer.WriteAttributeString("lat", location.Lat);
                                writer.WriteAttributeString("lon", location.Lon);
                                writer.WriteEndElement();
                            }
                        }
                    }
                }
            }
        }

        private static void GetLines(XmlNode linesNode, int currentIDNumeric, List<RouteLine> lines, List<RouteStop> stops)
        {
            foreach (XmlElement line in linesNode)
            {
                int lineID = int.Parse(line.Attributes["id"].Value);
                string lineName = line.Attributes["publicName"].Value;
                RouteLine currentLine = new RouteLine(lineID, lineName, currentIDNumeric);
                lines.Add(currentLine);

                foreach (XmlElement route in line)
                {
                    int currentRouteID = int.Parse(route.Attributes["route_id"].Value);
                    string currentRouteName = route.Attributes["publicName"].Value;

                    Route currentRoute = new Route(currentRouteID, currentRouteName);

                    var currentChildNode = route.ChildNodes[0];
                    int currentChildID = int.Parse(currentChildNode.Attributes["id"].Value);

                    RouteStop currentStop = null;
                    try
                    {
                        var tempStop = stops.Where(x => x.PublicID == currentChildID).First();
                        currentStop = tempStop.Clone() as RouteStop;
                    }
                    catch (InvalidOperationException)
                    {
                        currentStop = new RouteStop(currentChildID, "MISSING!");
                    }

                    for (int i = 1; i < route.ChildNodes.Count; i++)
                    {
                        if (route.ChildNodes[i].Name == "stopRef")
                        {
                            currentRoute.Stops.Add(currentStop);
                            currentChildNode = route.ChildNodes[i];
                            currentChildID = int.Parse(currentChildNode.Attributes["id"].Value);
                            try
                            {
                                var tempStop = stops.Where(x => x.PublicID == currentChildID).First();
                                currentStop = tempStop.Clone() as RouteStop;
                            }
                            catch (InvalidOperationException)
                            {
                                currentStop = new RouteStop(currentChildID, "MISSING!");
                            }
                        }
                        else
                        {
                            string lat = route.ChildNodes[i].Attributes["lat"].Value;
                            string lon = route.ChildNodes[i].Attributes["lon"].Value;

                            StopLocation currentStopLocation = new StopLocation(lat, lon);
                            currentStop.StopLocations.Add(currentStopLocation);
                        }
                    }

                    currentRoute.Stops.Add(currentStop);
                    currentLine.LineRoute.Add(currentRoute);
                }
            }
        }

        private static void GetStops(XmlNode stopsNode, List<RouteStop> stops)
        {
            foreach (XmlElement stop in stopsNode)
            {
                int stopID = int.Parse(stop.Attributes["id"].Value);
                int stopCode = int.Parse(stop.Attributes["code"].Value);
                string stopName = stop.Attributes["publicName"].Value;
                StopLocation stopLocation = new StopLocation(stop.Attributes["lat"].Value, stop.Attributes["lon"].Value);

                RouteStop currentStop = new RouteStop(stopID, stopName);
                currentStop.Code = stopCode;
                currentStop.DefaultLocation = stopLocation;
                stops.Add(currentStop);
            }
        }
    }
}
