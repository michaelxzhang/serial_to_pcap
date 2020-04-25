# serial_to_pcap
Convert serial communication traffic to pcapng that could be read and analyzed by Wireshark.

For example, sometime you have the protocol traffic, and you want to analyze it. 
Use this tool, you can convert your protocol traffic into pcapng and load with Wireshark.

Wirtten by C# and AutoHotKey scripts.

Currently supported protocol: 
  1) DNP3.0
  2) IEC 60870-5-101
  3) IEC 60870-5-103
  4) IEC 60870-5-104
  5) Modbus TCP

Note: This tool will format the seleted captured serial traffic into the format that could be read by text2pcap, then call text2pcap to covert the file into pcapng.

text2pcap.exe default execute path is "C:\Program Files\Wireshark\text2pcap.exe".(Maybe consider put this path in a text file) 
  
Input format:

[13:53:45.063] Rx <= 
68 12 12 68 08 01 0A 81 02 01 FE F1 00 01 02 
01 01 04 02 01 AA 2A 66 16
[13:53:45.065] Tx <= 
68 12 12 68 08 01 0A 81 02 01 FE F1 00 01 02 
02 01 04 02 01 AA 2A 67 16

Time stampe need start with [, and with Rx or Tx in the line;

Current support 15 data per line, can be configured in the future;

The input file will be formatted to a temperaory file with different name, added '_n' at the input filename.

The output will be pcapng file.
