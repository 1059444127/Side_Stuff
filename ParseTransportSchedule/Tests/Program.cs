using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using TransportSchedulesClasses;

namespace Tests
{
    class Test
    {
        static void Main()
        {
            XmlDocument routes = new XmlDocument();
            string fullPath = @"C:\Users\Kickass\Desktop\Ceco\DEMO_routes_aaa.xml";
            routes.Load(@"C:\Users\Kickass\Desktop\Ceco\DEMO_routes_aaa.xml");
            var nodes = routes.DocumentElement.SelectNodes("/transportationNetwork/vehicleType");

            List<RouteStop> stops = new List<RouteStop>();
            List<RouteLine> lines = new List<RouteLine>();
            foreach (XmlElement vehicleTypeNode in nodes)
            {
                var currentId = vehicleTypeNode.Attributes["id"];
                int currentIDNumeric = int.Parse(currentId.Value);

                var stopsNode = vehicleTypeNode.FirstChild;
                var linesNode = vehicleTypeNode.LastChild;

                GetStops(stopsNode, stops);

                GetLines(linesNode, currentIDNumeric, lines, stops);
            }

            string dirPath = Path.GetDirectoryName(fullPath);
            Directory.CreateDirectory(dirPath + "\\Processed Routes");

            #region XmlWriterSettings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "    ";
            #endregion

            WriteProcessedRoutes(lines, dirPath, settings);

            XmlDocument timetables = new XmlDocument();
            string fullTimetablesPath = @"C:\Users\Kickass\Desktop\Ceco\timetables_aaa.xml";
            timetables.Load(fullTimetablesPath);

            var mainNodes = timetables.DocumentElement.SelectNodes("/schedules/vehicleType");
            List<int> timetableLineOrder = new List<int>();
            List<RouteStop> timetableStops = new List<RouteStop>();

            ExtractTimetableTimes(mainNodes, stops, timetableLineOrder, timetableStops);

            foreach (var line in timetableLineOrder)
            {
                List<RouteStop> currentStops = new List<RouteStop>();

                foreach (var stop in timetableStops)
                {
                    foreach (var schedule in stop.LineToStopSchedule)
                    {
                        if (schedule.LineID == line)
                        {
                            currentStops.Add(stop);
                            break;
                        }
                    }
                }

                RouteStop[] orderedStops = null;
                try
                {

                    orderedStops = currentStops.OrderBy(x => x.LineToStopSchedule.Where(y => y.LineID == line).First().TimeAtStop[0]).ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                RouteLine currentLine = null;

                try
                {
                    currentLine = lines.Where(x => x.LineID == line).First();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Invalid TimeTable data");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Directory.CreateDirectory(String.Format("{0}\\Processed Routes\\{1}\\Timetables", dirPath, currentLine.Name));
                int tripCounter = 1;
                int indexCounter = 0;

                bool loopAlive = true;
                while (loopAlive)
                {
                    string currentFileName = String.Format("{0}\\Processed Routes\\{1}\\Timetables\\{2}.xml", dirPath, currentLine.Name, tripCounter);

                    using (XmlWriter writer = XmlWriter.Create(currentFileName, settings))
                    {
                        writer.WriteStartElement("schedules");
                        writer.WriteStartElement("vehicleType");
                        writer.WriteAttributeString("id", currentLine.VehicleType.ToString());

                        foreach (var stop in orderedStops)
                        {
                            var currentLineToStopSchedule = stop.LineToStopSchedule.Where(x => x.LineID == line).First();

                            writer.WriteStartElement("stopRef");
                            writer.WriteAttributeString("id", stop.PublicID.ToString());
                            try
                            {
                                writer.WriteStartElement("lineRef");
                                writer.WriteAttributeString("id", line.ToString());
                                writer.WriteValue(currentLineToStopSchedule.TimeAtStop[indexCounter].TimeOfDay.ToString());
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (tripCounter < currentStops.Max(x => x.LineToStopSchedule[line].TimeAtStop.Count))
                                {
                                    MessageBox.Show(String.Format("There are missing times in Stop ID: {0}, Line ID: {1} at Trip: {2}", stop.PublicID, currentLine.LineID, tripCounter));
                                    writer.WriteElementString("lineRef", line.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Writing Timetables finished succesfully");
                                    writer.Flush();
                                    return;
                                }
                            }
                        }
                    }

                    tripCounter++;
                    indexCounter++;
                }
            }
        }
  
        private static void ExtractTimetableTimes(XmlNodeList mainNodes, List<RouteStop> stops, List<int> timetableLineOrder, List<RouteStop> timetableStops)
        {
            foreach (XmlElement vehicleTypeNode in mainNodes)
            {
                int vehicleTypeID = int.Parse(vehicleTypeNode.Attributes["id"].Value);

                foreach (XmlElement stopRef in vehicleTypeNode)
                {
                    var currentStop = stops.Where(x => x.PublicID == int.Parse(stopRef.Attributes["id"].Value)).First();

                    foreach (XmlElement lineRef in stopRef)
                    {
                        int lineID = int.Parse(lineRef.Attributes["id"].Value);
                        var timesAtStop = SplitTimeNode(lineRef.InnerText, lineID);
                        currentStop.LineToStopSchedule.Add(timesAtStop);

                        if (!timetableLineOrder.Contains(lineID))
                        {
                            timetableLineOrder.Add(lineID);
                        }
                    }

                    timetableStops.Add(currentStop);
                }
            }
        }

        static LineToStopSchedule SplitTimeNode(string departureTimes, int lineID)
        {
            string departureTimesTrimmed = departureTimes.Replace("\r\n", String.Empty).Trim();
            LineToStopSchedule result = new LineToStopSchedule(lineID);
            string[] splitDepartureTimes = departureTimesTrimmed.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var time in splitDepartureTimes)
            {
                DateTime currentTime = DateTime.Parse(time);
                result.TimeAtStop.Add(currentTime);
            }

            return result;
        }
  
        private static void WriteProcessedRoutes(List<RouteLine> lines, string dirPath, XmlWriterSettings settings)
        {
            foreach (var line in lines)
            {
                string currentPath = String.Format("{0}\\Processed Routes\\{1}", dirPath, line);
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
