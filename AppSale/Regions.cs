using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace AppSale
{
	public class Regions
	{
		string id;
		int westernCape;
        int sportsAndOutdoor;
        int pets;
        bool done;


        //FASHION & BEAUTY,
        //    SPORTS & OUTDOOR,
        //    PETS,
        //    VEHICLES,
        //    HOME IMPROVEMENT, 
        //    BABIES/CHILDREN,
        //    HOBBIES/INTERESTS,
        //    MOBILE PHONES & ACCESSORIES,
        //    HOME APPLIANCES, 
        //    GAMING, 
        //    BOOKS, 
        //    MUSIC



        [JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value;}
		}

		[JsonProperty(PropertyName = "text1")]
		public int WesternCape
        {
			get { return westernCape; }
			set { westernCape = value;}
		}

        [JsonProperty(PropertyName = "text2")]
        public int SportsAndOutdoor
        {
            get { return sportsAndOutdoor; }
            set { sportsAndOutdoor = value; }
        }

        [JsonProperty(PropertyName = "text3")]
        public int Pets
        {
            get { return pets; }
            set { pets = value; }
        }

        [JsonProperty(PropertyName = "complete")]
		public bool Done
		{
			get { return done; }
			set { done = value;}
		}

        [Version]
        public string Version { get; set; }
	}
}

