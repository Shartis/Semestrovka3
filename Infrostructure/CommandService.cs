﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Semestrovka4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Semestrovka4.Infrostructure
{

    public delegate bool CommandAction(out string message, params string[] args);
    public class CommandService
    {
        private ConcurrentDictionary<string, CommandAction> _commands;

        public CommandService()
        {
            _commands = new ConcurrentDictionary<string, CommandAction>();
        }

        public void AddCommand(string keyword, CommandAction action)
        {
            _commands.TryAdd(keyword, action);
        }

        public bool TryExecuteCommand(string command, out string message)
        {
            var splited = command.Split(' ');
            message = null;

            if (splited.Length <= 0 ||
                !_commands.TryGetValue(splited[0], out var action))
                return false;

            var result = action(out message, splited.Skip(1).ToArray());
            return result;
        }
    }
}
