
using System.Globalization;
using System.Xml;

internal class Program
{
    class Piece 
    {
        public string Composer;
        public string Key;
    }

    static void Main()
    {
        Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
        int numOfPieces = int.Parse(Console.ReadLine());  

        for (int i = 0; i < numOfPieces; i++)
        {
            string[] splittedInput = Console.ReadLine().Split("|");

            string piece = splittedInput[0];
            string composer = splittedInput[1];
            string key = splittedInput[2];

            Piece pieceObj = new Piece() { Composer = composer, Key = key };

            pieces.Add(piece, pieceObj);

        }

        string input;
        while ((input = Console.ReadLine()) != "Stop") 
        {
            string[] splittedInput2 = input.Split("|");

            if (splittedInput2[0] == "Add")
            {
                string piece = splittedInput2[1];
                string composer = splittedInput2[2];
                string key = splittedInput2[3];

                if (!pieces.ContainsKey(piece))
                {
                    pieces.Add(piece, new Piece() { Composer = composer, Key = key });
                    Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                }
                else
                {
                    Console.WriteLine($"{piece} is already in the collection!"
);
                }
            }
            else if (splittedInput2[0] == "Remove")
            {
                string piece = splittedInput2[1];

                if (pieces.ContainsKey(piece))
                {
                    pieces.Remove(piece);
                    Console.WriteLine($"Successfully removed {piece}!");
                    pieces = new Dictionary<string, Piece>(pieces);
                }
                else
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }
            }
            else if (splittedInput2[0] == "ChangeKey")
            {
                string piece = splittedInput2[1];
                string newKey = splittedInput2[2];

                if (pieces.ContainsKey(piece))
                {
                    Piece currentPiece = pieces[piece];

                    currentPiece.Key = newKey;

                    Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                }
                else
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }
            }
        }


        foreach (var (piece, pieceObj) in pieces)
        {
            Console.WriteLine($"{piece} -> Composer: {pieceObj.Composer}, Key: {pieceObj.Key}");
        }
    }
}
