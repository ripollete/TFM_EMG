using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signalAcquirer
{
    public struct Olimexino328_packet
    {
        public byte sync0;		// = 0xa5
        public byte sync1;		// = 0x5a
        public byte version;	// = 2 (packet version)
        public byte count;		// packet counter. Increases by 1 each packet.
        public UInt16 d1;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public UInt16 d2;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public UInt16 d3;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public UInt16 d4;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public UInt16 d5;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public UInt16 d6;	// 10-bit sample (= 0 - 1023) in big endian (Motorola) format.
        public byte switches;	// State of PD5 to PD2, in bits 3 to 0.
    };
}
