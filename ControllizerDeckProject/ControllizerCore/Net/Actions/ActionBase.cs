/*
    Controllizer Deck - A DIY customizable controller deck
    Copyright (C) 2020  GhostyJade <ghostyjade2410@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Net;

namespace ControllizerCore.Net.Actions
{
    /// <summary>
    /// This class represent an abstraction for an HTTP Action. Every action must implement this class and register itself via <see cref="ActionManager.RegisterAction(ActionBase)"/>
    /// </summary>
    public abstract class ActionBase
    {
        /// <summary>
        /// Specifies the HTTP method required type to execute this action
        /// </summary>
        public enum HTTPType
        {
            GET,POST
        }

        /// <summary>
        /// The action name
        /// </summary>
        public string ActionName { get; private set; }
        /// <summary>
        /// The action URI where the frontend execute API calls
        /// </summary>
        public string ActionURI { get; private set; }
        /// <summary>
        /// The action type
        /// </summary>
        public HTTPType ActionType { get; private set; }

        public ActionBase(string name, string uri, HTTPType type)
        {
            ActionName = name;
            ActionURI = uri;
            ActionType = type;
        }

        /// <summary>
        /// Called when a POST request is received
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public virtual void OnPost(HttpListenerRequest request, HttpListenerResponse response) { }

        /// <summary>
        /// Called when a GET request is received
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public virtual void OnGet(HttpListenerRequest request, HttpListenerResponse response) { }

    }
}
