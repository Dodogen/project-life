using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PL.Core.Utils
{
	public static class Device
	{
		public static class OS
		{
			private static bool gotInfo = false;
			private const string keyFolder = "Win32_OperatingSystem";
			private static ManagementObjectSearcher infoContainer;

			public static string Caption
			{
				get
				{
					if (!gotInfo)
					{
						infoContainer = new ManagementObjectSearcher("root\\CIMV2",
								"SELECT * FROM " +keyFolder);
						gotInfo = true;
					}
					
					return infoContainer.Get()
						.Cast<ManagementObject>()
						.First()["Caption"]
						.ToString();
				}
			}
		}

		public static class Processor
		{
			private static bool gotInfo = false;
			private const string keyFolder = "Win32_Processor";
			private static ManagementObjectSearcher infoContainer;

			public static string Name
			{
				get
				{
					if (!gotInfo)
					{
						infoContainer = new ManagementObjectSearcher("root\\CIMV2",
							"SELECT * FROM " + keyFolder);
						gotInfo = true;
					}

					return infoContainer.Get()
						.Cast<ManagementObject>()
						.First()["Name"]
						.ToString();
				}
			}
			
			public static string NumberOfCores
			{
				get
				{
					if (!gotInfo)
					{
						infoContainer = new ManagementObjectSearcher("root\\CIMV2",
							"SELECT * FROM " + keyFolder);
						gotInfo = true;
					}

					return infoContainer.Get()
						.Cast<ManagementObject>()
						.First()["NumberOfCores"]
						.ToString();
				}
			}
		}

		public static class RAM
		{
			private static bool gotInfo = false;
			private const string keyFolder = "Win32_PhysicalMemory";
			private static ManagementObjectSearcher infoContainer;

			public static long Capacity
			{
				// return capacity in bytes
				get
				{
					if (!gotInfo)
					{
						infoContainer = new ManagementObjectSearcher("root\\CIMV2",
							"SELECT * FROM " + keyFolder);
						gotInfo = true;
					}

					return long.Parse(infoContainer
						.Get()
						.Cast<ManagementObject>()
						.First()["Capacity"]
						.ToString());
				}
			}

		}
	}
}
