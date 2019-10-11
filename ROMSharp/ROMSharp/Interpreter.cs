using System;
using System.Collections.Generic;
using System.Linq;
using ROMSharp.Enums;
using ROMSharp.Interfaces;

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
            ICommand matchedCommand;

			// Split commandString for easier handling
			string[] commandArr = input.Split (' ');

			// The first word of a user input is the command - isolate it
			string command = commandArr[0].ToLower().Trim();

            // If the command is "!", re-execute the player's last command
            if (command.Equals("!") && state.LastCommand != null)
                matchedCommand = state.LastCommand;
            else
            {
                // Try to find a matching command
                IEnumerable<ICommand> matchedCommands = Program.commandTable.Where(cmd => cmd.MinimumLevel <= state.PlayerCharacter.Trust && cmd.Name.ToLower().Equals(command.Trim().ToLower()) || cmd.Aliases.Contains(command.Trim().ToLower()));

                // If we got one or more commands, execute the first match
                if (matchedCommands.Count() > 0)
                {
                    // Grab the matched command
                    matchedCommand = matchedCommands.First();

                    // Store this as the player's last command executed
                    state.LastCommand = matchedCommand;
                }
                else
                {
                    // Not sure what they're looking for
                    Network.Send("Huh?\n\r", state);
                    return;
                }
            }

            // Check the character's position vs. the command's minimum
            if ((int)state.PlayerCharacter.Position.PositionCode < (int)matchedCommand.MinimumPosition)
            {
                switch (state.PlayerCharacter.Position.PositionCode)
                {
                    case Position.Dead:
                        Network.Send("Lie still; you are DEAD.\n\r", state);
                        break;
                    case Position.MortallyWounded:
                    case Position.Incapacitated:
                        Network.Send("You are hurt far too badly for that.\n\r", state);
                        break;
                    case Position.Stunned:
                        Network.Send("You are too stunned to do that.\n\r", state);
                        break;
                    case Position.Sleeping:
                        Network.Send("In your dreams, or what?\n\r", state);
                        break;
                    case Position.Resting:
                        Network.Send("Nah... You feel too relaxed...\n\r", state);
                        break;
                    case Position.Sitting:
                        Network.Send("Better stand up first.\n\r", state);
                        break;
                    case Position.Fighting:
                        Network.Send("No way! You are still fighting!\n\r", state);
                        break;
                }

                return;
            }

            // Execute the command
            matchedCommand.Execute(state.PlayerCharacter, commandArr);
        }
	}
}