using System;
using System.Linq;
using ROMSharp.Enums;

namespace ROMSharp
{
	public class Interpreter
	{
		public static void InterpretInput (string input, int connID)
		{
			Network.ClientConnection state = Network.ClientConnections.Single (c => c.ID == connID);

			// If we have no data, there's nothing to do
			if (String.IsNullOrWhiteSpace (input)) {
				Network.Send ("", state);
				return;
			}

			// Check what the client's state is to determine how to proceed
			switch (state.State) {
				// At idle, treat the input as a command with arguments
				case Enums.ClientState.Idle:
					ParseCommand (input, connID);
					break;

				// Waiting for the character name (logging in)
				case ClientState.Login_WaitingForCharacterName:
					// Is the name legal?
					if (Character.IsLegalName (input.Trim())) {
                        // Instantiate a new Character in the user's state and set the name
                        state.PlayerCharacter = new Models.PlayerCharacterData();

                        // Do we recognize this username?
                        if (Character.Exists (input)) {
							// It's a known character, start the login process - update the user state.
							state.State = ClientState.Login_WaitingForPassword;

							// Send the Password: prompt
							Network.Send (Consts.Strings.LoginPasswordPrompt, state);
						} else {
							// It's an unknown character, start the creation process - update the user state.
							state.State = ClientState.Creation_WaitingForPassword;

                            // Send the password prompt
							Network.Send (state.workSocket, String.Format ("{0} {1}: ", Consts.Strings.CreationPasswordPrompt, input), state, false);

                            // Send the local echo off command
                            Network.SendCommand(state.workSocket, Consts.Misc.TelnetCommands.LocalEchoOff, state);
						}
					} else {
						// Illegal name - leave the state as is, tell the user to try again
						Network.Send (Consts.Strings.LoginCharacterNameIllegal, state);
					}
					break;

                case ClientState.Creation_WaitingForPassword:
                    // Ensure the password meets requirements
                    if (Password.MeetsComplexityRequirements(input))
                    {
                        // Password is good - update the user state then prompt for the user to repeat the password
                        state.State = ClientState.Creation_WaitingForPasswordConfirm;

                        // Store the password temporarily
                        state.TempPass = input;

                        // Prompt for confirmation
                        Network.Send("\n\r" + Consts.Strings.CreationPasswordConfirmPrompt, state);
                    }
                    else
                    {
                        // Password isn't good - roll the user state back then re-prompt for a password
                        state.State = ClientState.Creation_WaitingForPassword;

                        Network.Send("\n\r" + Consts.Strings.CreationInvalidPassword + "\n\r" + Consts.Strings.CreationPasswordPrompt, state);
                    }
                    break;
			}
		}

		public static void ParseCommand(string input, int connID)
		{
			Network.ClientConnection state = Network.ClientConnections.Single (c => c.ID == connID);

			// Split commandString for easier handling
			string[] commandArr = input.Split (' ');

			// The first word of a user input is the command - isolate it
			string command = commandArr[0].ToLower ();

            // Determine what command was requested
            switch (command)
            {
                // Shut down the server
                case "shutdown":
                    ServerControl.Shutdown();
                    break;

                // Disconnect the client
                case "exit":
                    Network.EndSession(state);
                    break;

                // Request the current time
                case "whattimeisit":
                    Commands.WhatTimeIsIt(state.ID);
                    break;

                // Request a list of current connections
                case "listconnections":
                    Commands.ListConnections(state.ID);
                    break;

                // Force a point pulse
                case "forcepointtick":
                    Commands.ForcePointPulse(state.ID);
                    break;

                // Repeats the last command
                case "!":
                    ParseCommand(state.LastCommand, state.ID);
                    break;

                case "serverstats":
                    Commands.DoServerStats(state.ID);
                    break;

                case "goto":
                    Commands.DoGoto(state.ID, commandArr[1]);
                    break;

                case "stat":
                    switch (commandArr[1])
                    {
                        case "room":
                            Commands.DoStatRoom(state.ID, Convert.ToInt32(commandArr[2]));
                            break;
                        default:
                            Commands.UnknownCommand(state.ID, command);
                            break;
                    }
                    break;

                case "look":
                    Commands.DoLook(state.ID, commandArr);
                    break;

                case "spawn":
                    Commands.DoSpawn(Convert.ToInt32(commandArr[1]), Convert.ToInt32(commandArr[2]), state.ID);
                    break;

                case "load":
                    Commands.DoLoad(state.ID, commandArr);
                    break;

                case "inv":
                case "inventory":
                    Commands.DoInventory(state.ID);
                    break;

                // Unknown command
                default:
                    Commands.UnknownCommand(state.ID, command);
                    break;
            }

			// Store the active command as the client's last command, if it wasn't !
			if (!command.Equals ("!"))
				state.LastCommand = command;
		}
	}
}