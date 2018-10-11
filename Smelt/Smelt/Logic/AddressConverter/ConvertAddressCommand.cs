namespace Smelt.Logic.AddressConverter
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using Data;

    public class ConvertAddressCommand : Command
    {
        public ConvertAddressCommand(AppState appState) : base(appState)
        {
        }

        protected override void Handle()
        {
            var inputAddress = AppState.InputAddress;

            if (!inputAddress.StartsWith("$") && !inputAddress.StartsWith("0x"))
            {
                throw new Exception("Input address needs to start with \"$\" or \"0x\"");
            }

            var addressString = Regex.Replace(inputAddress, "[^0-9A-Fa-f]", "");

            if (inputAddress.StartsWith("$"))
            {
                AppState.OutputAddress = $"0x{AppState.Rom.RomAddressToHexAddress(addressString):X6}";
            }

            if (inputAddress.StartsWith("0x"))
            {
                var addressValue = int.Parse(addressString, NumberStyles.AllowHexSpecifier);
                
                AppState.OutputAddress = $"${AppState.Rom.HexAddressToRomAddress(addressValue)}";
            }
        }
    }
}
