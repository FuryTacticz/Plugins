package Plugin;

import cn.nukkit.command.Command;
import cn.nukkit.command.CommandSender;
import cn.nukkit.plugin.PluginBase;
import cn.nukkit.utils.TextFormat;

public class Main extends PluginBase{

	
	public void onEnable() {
		this.getLogger().info(TextFormat.GREEN + "Plugin Loaded!");
	}
}