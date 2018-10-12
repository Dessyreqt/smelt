namespace Smelt.Tests.Logic.AddressConverter.ConvertAddress
{
    using System;
    using Data;
    using Shouldly;
    using Smelt.Logic;
    using Smelt.Logic.AddressConverter;

    public class WhenTryingToConvertBadFormatAddresses
    {
        private readonly AppState appState;

        public WhenTryingToConvertBadFormatAddresses()
        {
            appState = new AppState { Rom = new Rom() };
            appState.Rom.Header.Makeup.Mapping = Mapping.LoRom;
            appState.InputAddress = "12DEAD";
        }

        public void ShouldThrowException()
        {
            Should.Throw<Exception>(() => Command.Run(new ConvertAddressCommand(appState)));
        }
    }
}
