using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private int[,] board;

    enum Pieces
    {
        BLACK_KING,
        BLACK_QUEEN,
        BLACK_BISHOP,
        BLACK_KNIGHT,
        BLACK_ROOK,
        BLACK_PAWN,
        WHITE_KING,
        WHITE_QUEEN,
        WHITE_BISHOP,
        WHITE_KNIGHT,
        WHITE_ROOK,
        WHITE_PAWN
    };

    // Start is called before the first frame update
    void Start()
    {
        board = new int[8, 8];
        InitializeBoard();
        PopulateBoard();
        PrintBoard();
        FillBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintBoard()
    {
        string s = "";
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                s += board[x, y] + "|";
            }
            s += "\n";
        }
        Debug.Log(s);
    }

    void InitializeBoard()
    {
        for(int i = 0; i<8;i++)
        {
            for(int j = 0;j<8;j++)
            {
                board[i, j] = -1;
            }
        }
    }

    void PopulateBoard()
    {
        for(int i = 0; i<8;i++)
        {
            board[i, 1] = (int)Pieces.WHITE_PAWN;
            board[i, 6] = (int)Pieces.BLACK_PAWN;
        }
        board[0, 0] = (int)Pieces.WHITE_ROOK;
        board[7, 0] = (int)Pieces.WHITE_ROOK;
        board[1, 0] = (int)Pieces.WHITE_KNIGHT;
        board[6, 0] = (int)Pieces.WHITE_KNIGHT;
        board[2, 0] = (int)Pieces.WHITE_BISHOP;
        board[5, 0] = (int)Pieces.WHITE_BISHOP;
        board[3, 0] = (int)Pieces.WHITE_QUEEN;
        board[4, 0] = (int)Pieces.WHITE_KING;

        board[0, 7] = (int)Pieces.BLACK_ROOK;
        board[7, 7] = (int)Pieces.BLACK_ROOK;
        board[1, 7] = (int)Pieces.BLACK_KNIGHT;
        board[6, 7] = (int)Pieces.BLACK_KNIGHT;
        board[2, 7] = (int)Pieces.BLACK_BISHOP;
        board[5, 7] = (int)Pieces.BLACK_BISHOP;
        board[3, 7] = (int)Pieces.BLACK_KING;
        board[4, 7] = (int)Pieces.BLACK_QUEEN;
    }

    string GetPrefabName(int enumNumber)
    {
        switch (enumNumber)
        {
            case (int)Pieces.BLACK_KING: return "bKing"; break;
            case (int)Pieces.BLACK_QUEEN: return "bQueen"; break;
            case (int)Pieces.BLACK_BISHOP: return "bBishop"; break;
            case (int)Pieces.BLACK_KNIGHT: return "bKnight"; break;
            case (int)Pieces.BLACK_ROOK: return "bRook"; break;
            case (int)Pieces.BLACK_PAWN: return "bPawn"; break;
            case (int)Pieces.WHITE_KING: return "wKing"; break;
            case (int)Pieces.WHITE_QUEEN: return "wQueen"; break;
            case (int)Pieces.WHITE_BISHOP: return "wBishop"; break;
            case (int)Pieces.WHITE_KNIGHT: return "wKnight"; break;
            case (int)Pieces.WHITE_ROOK: return "wRook"; break;
            case (int)Pieces.WHITE_PAWN: return "wPawn"; break;
        }
        return "";
    }

    void FillBoard()
    {
        for (int i=0;i<8;i++)
        {
            for(int j=0;j<8;j++)
            {
                if (board[j,i] > -1)
                {
                    Vector3 pos = new Vector3(j * 1.1142857f, 0, i * 1.1142857f);
                    string name = GetPrefabName(board[j, i]);
                    Instantiate(Resources.Load(name), pos, Quaternion.identity);
                }
            }
        }
    }
}
