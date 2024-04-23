using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI playerIndicator;
   
   [SerializeField] GameObject[] buttonsImageBoard;
   [SerializeField] GameObject[] horizontalWinLines;
   [SerializeField] GameObject[] verticalWinLines;
   [SerializeField] GameObject[] diagonalWinLines;
   
   [SerializeField] private Sprite xSprite;
   [SerializeField] private Sprite oSprite;

   [SerializeField] private GameObject restartButton;

   private void Start()
   {
      playerIndicator.text = "Player 1";
   }

   public void SetCellSprite(int index, bool isPlayer1Turn)
   {
      buttonsImageBoard[index].GetComponent<UnityEngine.UI.Image>().sprite = isPlayer1Turn ? xSprite : oSprite;
   }
   public void ChangePlayerIndicator(bool isPlayer1Turn)
   {
      playerIndicator.text = isPlayer1Turn ? "Player 1" : "Player 2";
   }
   
   public void ShowVerticalWinLine(int index)
   {
      verticalWinLines[index].SetActive(true);
   }
   public void ShowHorizontalWinLine(int index)
   {
      horizontalWinLines[index].SetActive(true);
   }
   public void ShowDiagonalWinLine(int index)
   {
      diagonalWinLines[index].SetActive(true);
   }

   public void ShowGameOverUI(bool isTie, bool isPlayer1Turn)
   {
      playerIndicator.text = isTie ? "Tie!" : isPlayer1Turn ? "Player 1 wins!" : "Player 2 wins!";
      restartButton.SetActive(true);
   }

   public void ToTheMenu()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
   }
}
