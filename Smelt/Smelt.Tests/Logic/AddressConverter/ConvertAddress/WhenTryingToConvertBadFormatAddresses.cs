namespace Smelt.Tests.Logic.AddressConverter.ConvertAddress
{
    using Shouldly;
    using Smelt.Data;
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
            Should.Throw<ConvertAddressException>(() => Command.Run(new ConvertAddressCommand(appState)));
        }
    }
}
