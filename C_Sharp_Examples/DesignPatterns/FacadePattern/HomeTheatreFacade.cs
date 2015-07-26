using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.FacadePattern
{
    public class HomeTheatreFacade
    {
        private Amplifier _amplifier;
        private Tunner _tunner;
        private DvdPlayer _dvdPlayer;
        private CdPlayer _cdPlayer;

        public HomeTheatreFacade(
            Amplifier amplifier,
            CdPlayer cdPlayer,
            DvdPlayer dvdPlayer,
            Tunner tunner)
        {
            _amplifier = amplifier;
            _tunner = tunner;
            _dvdPlayer = dvdPlayer;
            _cdPlayer = cdPlayer;
        }

        public void ThrowParty()
        {
            _amplifier.On();
            _cdPlayer.Off();
            _dvdPlayer.On();
            _amplifier.SetDvd();
            _amplifier.SetStereoSound();
            _tunner.On();
        }
    }
}
