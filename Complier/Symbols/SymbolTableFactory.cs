namespace Complier.Symbols
{
    public static class SymbolTableFactory
    {
        public static SymbolTable Current;

        public static SymbolTable CreateDefaultTable()
        {
            Current= new Default_SymbolTable();
            return Current;
        }
    }

}
