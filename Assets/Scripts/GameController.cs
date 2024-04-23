using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameUIController GameUIController;
    private int[,] _board = {{0,0,0},
                             {0,0,0},
                             {0,0,0}};
    private bool _player1Turn;
    private int _turnCount;
    private bool _isGameOver;
    private bool _isTie;
    void Start()
    {
        _player1Turn = true;
        _turnCount = 0;
        _isGameOver = false;
        _isTie = false;
    }

    public void Turn(int index)
    {
        if (index < 3)
        {
            _board[0, index] = _player1Turn ? 1 : 2;
        }
        else if (index < 6)
        {
            _board[1, index - 3] = _player1Turn ? 1 : 2;
        }
        else
        {
            _board[2, index - 6] = _player1Turn ? 1 : 2;
        }
        GameUIController.SetCellSprite(index, _player1Turn);
        
        _turnCount++;
        if (_turnCount > 4)
        {
            CheckBoard();
        }

        if (_isGameOver == false)
        {
            _player1Turn = !_player1Turn;
            GameUIController.ChangePlayerIndicator(_player1Turn);
        }
    }

    private void CheckBoard()
    {
        if (_isGameOver == false)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] != 0 && _board[i, 0] == _board[i, 1] && _board[i, 0] == _board[i, 2])
                {
                    GameUIController.ShowHorizontalWinLine(i);
                    EndGame();
                    return;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (_board[0, i] != 0 && _board[0, i] == _board[1, i] && _board[0, i] == _board[2, i])
                {
                    GameUIController.ShowVerticalWinLine(i);
                    EndGame();
                    return;
                }
            }
            // Check diagonals
            if (_board[0, 0] != 0 && _board[0, 0] == _board[1, 1] && _board[0, 0] == _board[2, 2])
            {
                GameUIController.ShowDiagonalWinLine(0);
                EndGame();
                return;
            }

            if (_board[0, 2] != 0 && _board[0, 2] == _board[1, 1] && _board[0, 2] == _board[2, 0])
            {
                GameUIController.ShowDiagonalWinLine(1);
                EndGame();
                return;
            }
            if (_turnCount == 9)
            {
                _isTie = true;
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        _isGameOver = true;
        GameUIController.ShowGameOverUI( _isTie, _player1Turn);
    }
}
