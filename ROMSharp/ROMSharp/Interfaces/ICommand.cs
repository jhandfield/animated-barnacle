using ROMSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMSharp.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Name of the command (i.e. what the user types to call it)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Aliases for the command (e.g. "north" and "n" should be the same command)
        /// </summary>
        IEnumerable<string> Aliases { get; }

        /// <summary>
        /// Help text for the comand (e.g. when a user types "help look")
        /// </summary>
        string HelpText { get; }

        /// <summary>
        /// The minimum position at which this command can be used
        /// </summary>
        Enums.Position MinimumPosition { get; }

        /// <summary>
        /// Minium level this command is available to (generally used to restrict commands to immortals)
        /// </summary>
        int MinimumLevel { get; }

        /// <summary>
        /// Determine the log state of the command
        /// </summary>
        Enums.CommandLogLevel LogLevel { get; }

        /// <summary>
        /// Whether the command should be included in command lists
        /// </summary>
        bool Show { get; }

        void Execute(CharacterData ch, string[] args);
    }
}
