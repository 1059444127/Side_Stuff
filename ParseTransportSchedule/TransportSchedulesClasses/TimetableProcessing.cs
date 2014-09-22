using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TransportSchedulesClasses
{
    public static class TimetableProcessing
    {
        public static void ProcessTimetable(string timetablePath)
        {
            XmlDocument timetables = new XmlDocument();
            string dirPath = Path.GetDirectoryName(timetablePath);
            timetables.Load(timetablePath);

            var mainNodes = timetables.DocumentElement.SelectNodes("/schedules/vehicleType");

            if (mainNodes.Count <= 0)
            {
                throw new XmlException("File is either empty or not in a correct format!");
            }

            List<KeyValuePair<int, int>> timetableLineOrder = new List<KeyValuePair<int, int>>();
            List<RouteStop> timetableStops = new List<RouteStop>();

            ExtractTimetableTimes(mainNodes, timetableLineOrder, timetableStops);

            WriteTimetables(timetableLineOrder, timetableStops, dirPath);
        }

        private static void WriteTimetables(List<KeyValuePair<int, int>> timetableLineOrder, List<RouteStop> timetableStops, string dirPath)
        {
            foreach (var lineAndVehicleType in timetableLineOrder)
            {
                int line = lineAndVehicleType.Key;
                int vehicleID = lineAndVehicleType.Value;

                List<RouteStop> currentStops = GetCurrentStops(timetableStops, line);

                RouteStop[] orderedStops = null;
                
                orderedStops = currentStops.OrderBy(x => x.LineToStopSchedule.Where(y => y.LineID == line).First().TimeAtStop[0]).ToArray();

                #region XmlWriterSettings

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "    ";

                #endregion

                Directory.CreateDirectory(String.Format("{0}\\Timetables\\ID {1}", dirPath, line));
                int tripCounter = 1;
                int indexCounter = 0;

                int maxCount = -1;
                foreach (var stop in orderedStops)
                {
                    var currentStopSchedule = stop.GetScheduleByID(line);
                    if (currentStopSchedule.TimeAtStop.Count > maxCount)
                    {
                        maxCount = currentStopSchedule.TimeAtStop.Count;
                    }
                }

                bool loopAlive = true;
                for (int i = 0; i < maxCount - 1; i++)
                {
                    string currentFileName = String.Format("{0}\\Timetables\\ID {1}\\{2}.xml", dirPath, line, tripCounter);

                    using (XmlWriter writer = XmlWriter.Create(currentFileName, settings))
                    {
                        writer.WriteStartElement("schedules");
                        writer.WriteStartElement("vehicleType");
                        writer.WriteAttributeString("id", vehicleID.ToString());
                        writer.WriteStartElement("trip");
                        writer.WriteAttributeString("id", tripCounter.ToString());

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
                                //if (indexCounter < maxCount)
                                //{
                                //    MessageBox.Show(String.Format("There are missing times in Stop ID: {0}, Line ID: {1} at Trip: {2}", stop.PublicID, line, tripCounter));
                                //    writer.WriteElementString("lineRef", line.ToString());
                                //}
                                //else
                                //{
                                loopAlive = false;
                                break;
                                //}
                            }
                        }
                    }

                    tripCounter++;
                    indexCounter++;
                }
            }
        }

        private static List<RouteStop> GetCurrentStops(List<RouteStop> timetableStops, int line)
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

            return currentStops;
        }

        private static void ExtractTimetableTimes(XmlNodeList mainNodes, List<KeyValuePair<int, int>> timetableLineOrder, List<RouteStop> timetableStops)
        {
            foreach (XmlElement vehicleTypeNode in mainNodes)
            {
                int vehicleTypeID = int.Parse(vehicleTypeNode.Attributes["id"].Value);

                foreach (XmlElement stopRef in vehicleTypeNode)
                {
                    RouteStop currentRouteStop = new RouteStop();
                    int currentStopID = int.Parse(stopRef.Attributes["id"].Value);

                    currentRouteStop.PublicID = currentStopID;

                    foreach (XmlElement lineRef in stopRef)
                    {
                        int lineID = int.Parse(lineRef.Attributes["id"].Value);
                        string lineSchedule = lineRef.InnerText;

                        var currentLineSchedule = SplitTimeNode(lineSchedule, lineID);

                        currentRouteStop.LineToStopSchedule.Add(currentLineSchedule);

                        var lineIDAndVehicleType = new KeyValuePair<int, int>(lineID, vehicleTypeID);
                        if (!timetableLineOrder.Contains(lineIDAndVehicleType))
                        {
                            timetableLineOrder.Add(lineIDAndVehicleType);
                        }
                    }

                    timetableStops.Add(currentRouteStop);
                }
            }
        }

        private static LineToStopSchedule SplitTimeNode(string departureTimes, int lineID)
        {
            string departureTimesTrimmed = departureTimes.Replace("\r\n", String.Empty).Trim();
            LineToStopSchedule result = new LineToStopSchedule(lineID);
            string[] splitDepartureTimes = departureTimesTrimmed.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var time in splitDepartureTimes)
            {
                DateTime currentTime = DateTime.Parse(time);
                result.TimeAtStop.Add(currentTime);
            }

            return result;
        }
    }
}
