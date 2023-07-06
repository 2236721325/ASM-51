using System.Collections.Generic;

namespace Complier.Symbols
{
    /// <summary>
    /// 8051
    /// </summary>
    public class Default_SymbolTable : SymbolTable
    {
        public Default_SymbolTable()
        {
            InitTable();
        }

        private void InitTable()
        {
            Symbols = new List<Symbol>();
            AddNewSymbol("P0", 0x80, SymbolType.DATA,true);
            AddNewSymbol("SP", 0x81, SymbolType.DATA);
            AddNewSymbol("DPL", 0x82, SymbolType.DATA);
            AddNewSymbol("DPH", 0x83, SymbolType.DATA);
            AddNewSymbol("PCON", 0x87, SymbolType.DATA);
            AddNewSymbol("TCON", 0x88, SymbolType.DATA,true);
            AddNewSymbol("TMOD", 0x89, SymbolType.DATA);
            AddNewSymbol("TL0", 0x8a, SymbolType.DATA);
            AddNewSymbol("TL1", 0x8b, SymbolType.DATA);
            AddNewSymbol("TH0", 0x8c, SymbolType.DATA);
            AddNewSymbol("TH1", 0x8d, SymbolType.DATA);
            AddNewSymbol("P1", 0x90, SymbolType.DATA, true);
            AddNewSymbol("SCON", 0x98, SymbolType.DATA);
            AddNewSymbol("SBUF", 0x99, SymbolType.DATA);
            AddNewSymbol("P2", 0xa0, SymbolType.DATA);
            AddNewSymbol("IE", 0xa8, SymbolType.DATA, true);
            AddNewSymbol("P3", 0xb0, SymbolType.DATA, true);
            AddNewSymbol("IP", 0xb8, SymbolType.DATA, true);
            AddNewSymbol("PSW", 0xd0, SymbolType.DATA, true);
            AddNewSymbol("ACC", 0xe0, SymbolType.DATA, true);
            AddNewSymbol("B", 0xf0, SymbolType.DATA, true);
            AddNewSymbol("IT0", 0x88 + 0, SymbolType.BIT);
            AddNewSymbol("IE0", 0x88 + 1, SymbolType.BIT);
            AddNewSymbol("IT1", 0x88 + 2, SymbolType.BIT);
            AddNewSymbol("IE1", 0x88 + 3, SymbolType.BIT);
            AddNewSymbol("TR0", 0x88 + 4, SymbolType.BIT);
            AddNewSymbol("TF0", 0x88 + 5, SymbolType.BIT);
            AddNewSymbol("TR1", 0x88 + 6, SymbolType.BIT);
            AddNewSymbol("TF1", 0x88 + 7, SymbolType.BIT);

            AddNewSymbol("RI", 0x98 + 0, SymbolType.BIT);
            AddNewSymbol("TI", 0x98 + 1, SymbolType.BIT);
            AddNewSymbol("RB8", 0x98 + 2, SymbolType.BIT);
            AddNewSymbol("TB8", 0x98 + 3, SymbolType.BIT);



            AddNewSymbol("REN", 0x98 + 4, SymbolType.BIT);
            AddNewSymbol("SM2", 0x98 + 5, SymbolType.BIT);
            AddNewSymbol("SM1", 0x98 + 6, SymbolType.BIT);
            AddNewSymbol("SM0", 0x98 + 7, SymbolType.BIT);
            AddNewSymbol("EX0", 0xa8 + 0, SymbolType.BIT);
            AddNewSymbol("ET0", 0xa8 + 1, SymbolType.BIT);
            AddNewSymbol("EX1", 0xa8 + 2, SymbolType.BIT);
            AddNewSymbol("ET1", 0xa8 + 3, SymbolType.BIT);
            AddNewSymbol("ES", 0xa8 + 4, SymbolType.BIT);
            AddNewSymbol("EA", 0xa8 + 7, SymbolType.BIT);
            AddNewSymbol("RXD", 0xb0 + 0, SymbolType.BIT);
            AddNewSymbol("TXD", 0xb0 + 1, SymbolType.BIT);
            AddNewSymbol("INT0", 0xb0 + 2, SymbolType.BIT);
            AddNewSymbol("INT1", 0xb0 + 3, SymbolType.BIT);
            AddNewSymbol("T0", 0xb0 + 4, SymbolType.BIT);
            AddNewSymbol("T1", 0xb0 + 5, SymbolType.BIT);
            AddNewSymbol("WR", 0xb0 + 6, SymbolType.BIT);
            AddNewSymbol("RD", 0xb0 + 7, SymbolType.BIT);
            AddNewSymbol("PX0", 0xb8 + 0, SymbolType.BIT);
            AddNewSymbol("PT0", 0xb8 + 1, SymbolType.BIT);
            AddNewSymbol("PX1", 0xb8 + 2, SymbolType.BIT);
            AddNewSymbol("PT1", 0xb8 + 3, SymbolType.BIT);
            AddNewSymbol("PS", 0xb8 + 4, SymbolType.BIT);


            AddNewSymbol("P", 0xd0 + 0, SymbolType.BIT);
            AddNewSymbol("OV", 0xd0 + 2, SymbolType.BIT);
            AddNewSymbol("RS0", 0xd0 + 3, SymbolType.BIT);
            AddNewSymbol("RS1", 0xd0 + 4, SymbolType.BIT);
            AddNewSymbol("F0", 0xd0 + 5, SymbolType.BIT);
            AddNewSymbol("AC", 0xd0 + 6, SymbolType.BIT);
            AddNewSymbol("CY", 0xd0 + 7, SymbolType.BIT);
        }


        
    }

}
