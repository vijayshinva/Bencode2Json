using System;

namespace TorrentFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var torrent = TorrentFile.Parse("ubuntu-17.04-desktop-amd64.iso.torrent");
            Console.WriteLine(torrent.Comment);
        }
    }
}
