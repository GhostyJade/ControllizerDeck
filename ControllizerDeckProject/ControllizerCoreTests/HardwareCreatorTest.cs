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

using ControllizerDeckProject.Core.Hardware;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ControllizerCoreTests
{
    [TestClass]
    public class HardwareCreatorTest
    {
        [TestMethod]
        public void HardwareCreatorCostructor()
        {
            HardwareData creator = HardwareDataManager.LoadData("{\"PushButton\": {\"type\":\"list\", \"buttons\":[{\"id\": 1},{\"id\": 2}]},\"RotaryEncoder\": [{\"id\": 0,\"hasButton\": true}]}");
            Assert.AreEqual(creator.PushButtons.Count,2);
            Assert.AreEqual(creator.RotaryEncoders.Count, 1);
        }
    }
}
