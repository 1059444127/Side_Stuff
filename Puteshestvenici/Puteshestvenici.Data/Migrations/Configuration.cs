namespace Puteshestvenici.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Puteshestvenici.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PuteshestveniciDbContext>
    {
        private const string CitiesFileLocation = "../../../cities.json";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PuteshestveniciDbContext context)
        {
            if (context.Locations.Count() == 0)
            {
                string citiesPureString = string.Empty;
                using (var reader = new StreamReader(CitiesFileLocation))
                {
                    citiesPureString = reader.ReadToEnd();
                }

                var citiesObject = JObject.Parse(citiesPureString);
                var citiesToString = citiesObject["cities"].ToString();
                var cities = JsonConvert.DeserializeObject<IEnumerable<string>>(citiesToString);
                foreach (var city in cities)
                {
                    var currentCity = new Location()
                    {
                        Name = city
                    };

                    context.Locations.Add(currentCity);
                }

                context.SaveChanges();
            }
        }
    }
}
