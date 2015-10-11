using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using log4net;
using MiNET;
using MiNET.BlockEntities;
using MiNET.Blocks;
using MiNET.Effects;
using MiNET.Items;
using MiNET.Net;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiNET.Worlds;

namespace Warp
{
	[Plugin(PluginName = "Warp", Description = "Mega simple warp plugin XD", PluginVersion = "1.0", Author = "FuryTacticz")]
	public class Warp : Plugin
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (CoreCommands));

		private Dictionary<string, Level> _worlds = new Dictionary<string, Level>();

		protected override void OnEnable()
		{
			
		}
		
		[Command(Command = "warp")]
		public void Warp(Player player, string warp)
		{
			float x;
			float y;
			float z;

			switch (warp)
			{
				case "shop":
					x = 1;
					y = 2;
					z = 3;
					break;
				case "pvp":
					x = 1;
					y = 2;
					z = 3;
					break;
				case "wild":
					x = 100;
					y = 20;
					z = -119;
					break;
				default:
					return;
			}

			var playerLocation = new PlayerLocation
			{
				X = x,
				Y = y,
				Z = z,
				Yaw = 91,
				Pitch = 28,
				HeadYaw = 91
			};

			ThreadPool.QueueUserWorkItem(delegate(object state) { player.SpawnLevel(player.Level, playerLocation); }, null);

		}



		

		

		
	}
}