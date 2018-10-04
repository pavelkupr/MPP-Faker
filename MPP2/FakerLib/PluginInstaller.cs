using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using FakerLib.Generator;

namespace FakerLib
{
	internal class PluginInstaller
	{
		private List<IGenerator> plugins;
		internal IEnumerable<IGenerator> Plugins { get { return plugins; } }
		private readonly string pluginPath;

		internal PluginInstaller()
		{
			plugins = new List<IGenerator>();
			pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
			RefreshPlugins();
		}

		internal void RefreshPlugins()
		{
			plugins.Clear();

			DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
			if (!pluginDirectory.Exists)
				pluginDirectory.Create();
   
			var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
			foreach (var file in pluginFiles)
			{
				Assembly asm = Assembly.LoadFrom(file);
				var types = asm.GetTypes().
								Where(t => t.GetInterfaces().Contains(typeof(IGenerator)));
				
				foreach (Type type in types)
				{
					IGenerator plugin = Activator.CreateInstance(type) as IGenerator;
					plugins.Add(plugin);
				}
			}
		}
	}
}
