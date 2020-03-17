using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evidencia.Properties;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace Evidencia
{
	public class Record
	{
		public string id { get; set; }
		public string meta_prev { get; set; }
		public string meta_book { get; set; }
		public string meta_page { get; set; }
		public string meta_kategoria { get; set; }
		public string meta_kategoria_number { get; set; }
		public string meta_sap { get; set; }
		public string main_kategoria { get; set; }
		public string main_number { get; set; }
		public string main_year_tuke { get; set; }
		public string main_year_kteem { get; set; }
		public string main_year_record { get; set; }
		public string Private { get; set; }
		public string id_owner { get; set; }
		public string id_owner_temp { get; set; }
		public string data_name { get; set; }
		public string data_sort1 { get; set; }
		public string data_sort2 { get; set; }
		public string data_production_code { get; set; }
		public string data_price_sk { get; set; }
		public string data_price_eu { get; set; }
		public string data_repair { get; set; }
		public string data_discard { get; set; }
		public string data_rfid { get; set; }
		public string place_room_sap { get; set; }
		public string place_room { get; set; }
		public string place_locker { get; set; }
		public string place_shelve { get; set; }
		public string borrowed { get; set; }
		public string borrowed_date { get; set; }
		public string dummy1 { get; set; }
		public string dummy2 { get; set; }
		public string dummy3 { get; set; }
		public string dummy4 { get; set; }
		public string inr { get; set; }

		public override string ToString()
		{
			return	$" {inr}\t" +
					$" {meta_sap}\t" +
					$"{data_name}\t\t" +
					$"{place_room_sap}\t" +
					$"{place_locker}\t" +
					$" {place_shelve}";
		}
	}

	public class DataDb
	{
		public string ID { get; set; }
		public string meta_sap { get; set; }
		public string data_name { get; set; }
		public string place_room_sap { get; set; }
		public string place_locker { get; set; }
		public int place_shelve { get; set; }
	}

	public class DataTableRecords
	{
		[JsonProperty("ID")]
		public int ID { get; set; }

		[JsonProperty("meta_prev")]
		public string meta_prev { get; set; }

		[JsonProperty("meta_book")]
		public int meta_book { get; set; }

		[JsonProperty("meta_page")]
		public int meta_page { get; set; }

		[JsonProperty("meta_kategoria")]
		public string meta_kategoria { get; set; }

		[JsonProperty("meta_kategoria_number")]
		public int meta_kategoria_number { get; set; }

		[JsonProperty("meta_sap")]
		public int meta_sap { get; set; }

		[JsonProperty("main_kategoria")]
		public string main_kategoria { get; set; }

		[JsonProperty("main_number")]
		public int main_number { get; set; }

		[JsonProperty("main_year_tuke")]
		public int main_year_tuke { get; set; }

		[JsonProperty("main_year_kteem")]
		public int main_year_kteem { get; set; }

		[JsonProperty("main_year_record")]
		public int main_year_record { get; set; }

		[JsonProperty("private")]
		public string Private { get; set; }

		[JsonProperty("id_owner")]
		public string id_owner { get; set; }

		[JsonProperty("id_owner_temp")]
		public int id_owner_temp { get; set; }

		[JsonProperty("data_name")]
		public string data_name { get; set; }

		[JsonProperty("data_sort1")]
		public string data_sort1 { get; set; }

		[JsonProperty("data_sort2")]
		public string data_sort2 { get; set; }

		[JsonProperty("data_production_code")]
		public string data_production_code { get; set; }

		[JsonProperty("data_price_sk")]
		public float data_price_sk { get; set; }

		[JsonProperty("data_price_eu")]
		public float data_price_eu { get; set; }

		[JsonProperty("data_repair")]
		public string data_repair { get; set; }

		[JsonProperty("data_discard")]
		public string data_discard { get; set; }

		[JsonProperty("data_rfid")]
		public string data_rfid { get; set; }

		[JsonProperty("place_room_sap")]
		public string place_room_sap { get; set; }

		[JsonProperty("place_room")]
		public string place_room { get; set; }

		[JsonProperty("place_locker")]
		public string place_locker { get; set; }

		[JsonProperty("place_shelve")]
		public int place_shelve { get; set; }

		[JsonProperty("borrowed")]
		public int borrowed { get; set; }

		[JsonProperty("borrowed_date")]
		public DateTime? borrowed_date { get; set; }

		[JsonProperty("dummy1")]
		public string dummy1 { get; set; }

		[JsonProperty("dummy2")]
		public string dummy2 { get; set; }

		[JsonProperty("dummy3")]
		public string dummy3 { get; set; }

		[JsonProperty("dummy4")]
		public string dummy4 { get; set; }

		[JsonProperty("INR")]
		public string inr { get; set; }
	}

	public class DataTableUsers
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("nickname")]
		public string nickname { get; set; }

		[JsonProperty("access")]
		public int access { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Surname")]
		public string Surname { get; set; }

		[JsonProperty("InitializeKey")]
		public string InitializeKey { get; set; }

	}
	public class User
	{
		public string id { get; set; }
		public string nickname { get; set; }
		public string access { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string InitializeKey { get; set; }
		public override string ToString()
		{
			return $"{id}\t" +
					$"{nickname}\t" +
					$"{Name}\t" +
					$"{Surname}\t" +
					$" {InitializeKey}";
		}
	}

	public class DataTableNamespace
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("original_room")]
		public string original_room { get; set; }

		[JsonProperty("original_locker")]
		public string original_locker { get; set; }

		[JsonProperty("original_shelve")]
		public string original_shelve { get; set; }

		[JsonProperty("new")]
		public string New { get; set; }

	}
	public class Namespace
	{
		public string id { get; set; }
		public string original_room { get; set; }
		public string original_locker { get; set; }
		public string original_shelve { get; set; }
		public string New { get; set; }
		public override string ToString()
		{
			return $"{id}\t" +
					$"{original_room}\t" +
					$"{original_locker}\t" +
					$"{original_shelve}\t" +
					$" {New}";
		}
	}

}
