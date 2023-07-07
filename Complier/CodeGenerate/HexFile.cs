using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Complier.CodeGenerate
{
    public class HexFile
    {
        public IEnumerable<HexRecord> HexRecords { get; set; }
        public HexFile(IEnumerable<HexRecord> records)
        {
            HexRecords = records; 

        }

        public void WriteToFile(string file_path)
        {
            using (var writer = new StreamWriter(file_path))
            {
                foreach (var record in HexRecords)
                {
                    WriteDataRecord(writer, record.StartAddress, record.Bytes);
                }
                // Write end-of-file record
                writer.WriteLine(":00000001FF");
            }
        }
        private void WriteDataRecord(StreamWriter writer, int address, byte[] data)
        {
            int recordLength = data.Length;
            int checksum = recordLength + (address >> 8) + (address & 0xFF);
            writer.Write($":{recordLength:X2}{address:X4}00");
            foreach (var b in data)
            {
                writer.Write($"{b:X2}");
                checksum += b;
            }

            checksum = (~checksum + 1) & 0xFF;
            writer.WriteLine($"{checksum:X2}");
        }

        public string WriteToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                foreach (var record in HexRecords)
                {
                    WriteDataRecord(stringWriter, record.StartAddress, record.Bytes);
                }

                // Write end-of-file record
                stringWriter.WriteLine(":00000001FF");
            }

            return stringBuilder.ToString();
        }

        private void WriteDataRecord(TextWriter writer, int address, byte[] data)
        {
            int recordLength = data.Length;
            int checksum = recordLength + (address >> 8) + (address & 0xFF);

            writer.Write($":{recordLength:X2}{address:X4}00");

            foreach (var b in data)
            {
                writer.Write($"{b:X2}");
                checksum += b;
            }

            checksum = (~checksum + 1) & 0xFF;
            writer.WriteLine($"{checksum:X2}");
        }
    }
}
