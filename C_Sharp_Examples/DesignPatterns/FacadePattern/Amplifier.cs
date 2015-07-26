using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examples.DesignPatterns.FacadePattern
{
    public class Amplifier
    {
        private Tunner _tunner;
        private DvdPlayer _dvdPlayer;
        private CdPlayer _cdPlayer;

        public Amplifier(Tunner tunner, DvdPlayer dvdPlayer, CdPlayer cdPlayer)
        {
            _tunner = tunner;
            _dvdPlayer = dvdPlayer;
            _cdPlayer = cdPlayer;
        }

        public void On()
        {

        }

        public void Off()
        {

        }

        public void SetDvd()
        {

        }

        public void SetStereoSound()
        {

        }
    }
}
